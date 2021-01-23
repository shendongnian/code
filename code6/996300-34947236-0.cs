    namespace Smartodds.Framework.Redis
    {
        public class RedisClient : IDisposable
        {
            public RedisClient(RedisEnvironmentElement environment, Int32 databaseId)
            {
                m_ConnectTimeout = environment.ConnectTimeout;
                m_Timeout = environment.Timeout;
                m_DatabaseId = databaseId;
                m_ReconnectTime = environment.ReconnectTime;
                m_CheckSubscriptionsTime = environment.CheckSubscriptions;
                if (environment.TestWrite == true)
                {
                    m_CheckWriteTime = environment.TestWriteTime;
                }
    
                environment.Password.ToCharArray().ForEach((c) => m_Password.AppendChar(c));
    
                foreach (var server in environment.Servers)
                {
                    if (server.Type == ServerType.Redis)
                    {
                        // will be ignored if sentinel servers are used
                        m_RedisServers.Add(new RedisConnection { Address = server.Host, Port = server.Port });
                    }
                    else
                    {
                        m_SentinelServers.Add(new RedisConnection { Address = server.Host, Port = server.Port });
                    }
                }
            }
    
            public bool IsSentinel { get { return m_SentinelServers.Count > 0; } }
    
            public IDatabase Database { get { return _Redis.GetDatabase(m_DatabaseId); } }
    
            private ConnectionMultiplexer _Redis
            {
                get
                {
                    if (m_Connecting == true)
                    {
                        throw new RedisConnectionNotReadyException();
                    }
    
                    ConnectionMultiplexer redis = m_Redis;
                    if (redis == null)
                    {
                        throw new RedisConnectionNotReadyException();
                    }
    
                    return redis;
                }
            }
    
            private ConnectionMultiplexer _Sentinel
            {
                get
                {
                    if (m_Connecting == true)
                    {
                        throw new RedisConnectionNotReadyException("Sentinel connection not ready");
                    }
    
                    ConnectionMultiplexer sentinel = m_Sentinel;
                    if (sentinel == null)
                    {
                        throw new RedisConnectionNotReadyException("Sentinel connection not ready");
                    }
    
                    return sentinel;
                }
            }
    
            public void RegisterSubscription(string channel, Action<RedisChannel, RedisValue> handler, Int32 maxNoReceiveSeconds)
            {
                m_Subscriptions.Add(channel, new RedisSubscription
                {
                    Channel = channel,
                    Handler = handler,
                    MaxNoReceiveSeconds = maxNoReceiveSeconds,
                    LastUsed = DateTime.UtcNow,
                });
            }
    
            public void Connect()
            {
                _Connect(true);
            }
    
            private void _Connect(object state)
            {
                bool throwException = (bool)state;
    
                // if a reconnect is already being attempted, don't hang around waiting
                if (Monitor.TryEnter(m_ConnectionLocker) == false)
                {
                    return;
                }
    
                // we took the lock, notify everything we are connecting
                m_Connecting = true;
    
                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    LoggerQueue.Debug(">>>>>> REDIS CONNECTING... >>>>>>");
    
                    // if this is a reconnect, make absolutely sure everything is cleaned up first
                    _KillTimers();
                    _KillRedisClient();
    
                    if (this.IsSentinel == true && m_Sentinel == null)
                    {
                        LoggerQueue.Debug(">>>>>> CONNECTING TO SENTINEL >>>>>> - " + sw.Elapsed);
    
                        // we'll be getting the redis servers from sentinel
                        ConfigurationOptions sentinelConnection = _CreateRedisConfiguration(CommandMap.Sentinel, null, m_SentinelServers);
                        m_Sentinel = ConnectionMultiplexer.Connect(sentinelConnection);
                        LoggerQueue.Debug(">>>>>> CONNECTED TO SENTINEL >>>>>> - " + sw.Elapsed);
    
                        _OutputConfigurationFromSentinel();
    
                        // get all the redis servers from sentinel and ignore any set by caller
                        m_RedisServers.Clear();
                        m_RedisServers.AddRange(_GetAllRedisServersFromSentinel());
    
                        if (m_RedisServers.Count == 0)
                        {
                            throw new RedisException("Sentinel found no redis servers");
                        }
                    }
    
                    LoggerQueue.Debug(">>>>>> CONNECTING TO REDIS >>>>>> - " + sw.Elapsed);
    
                    // try to connect to all redis servers
                    ConfigurationOptions connection = _CreateRedisConfiguration(CommandMap.Default, _SecureStringToString(m_Password), m_RedisServers);
                    m_Redis = ConnectionMultiplexer.Connect(connection);
                    LoggerQueue.Debug(">>>>>> CONNECTED TO REDIS >>>>>> - " + sw.Elapsed);
    
                    // register subscription channels
                    m_Subscriptions.ForEach(s =>
                    {
                        m_Redis.GetSubscriber().Subscribe(s.Key, (channel, value) => _SubscriptionHandler(channel, value));
                        s.Value.LastUsed = DateTime.UtcNow;
                    });
    
                    if (this.IsSentinel == true)
                    {
                        // check subscriptions have been sending messages
                        if (m_Subscriptions.Count > 0)
                        {
                            m_CheckSubscriptionsTimer = new Timer(_CheckSubscriptions, null, 30000, m_CheckSubscriptionsTime);
                        }
    
                        if (m_CheckWriteTime != null)
                        {
                            // check that we can write to redis
                            m_CheckWriteTimer = new Timer(_CheckWrite, null, 32000, m_CheckWriteTime.Value);
                        }
    
                        // monitor for connection status change to any redis servers
                        m_Redis.ConnectionFailed += _ConnectionFailure;
                        m_Redis.ConnectionRestored += _ConnectionRestored;
                    }
    
                    LoggerQueue.Debug(string.Format(">>>>>> ALL REDIS CONNECTED ({0}) >>>>>>", sw.Elapsed));
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error(">>>>>> REDIS CONNECT FAILURE >>>>>>", ex);
    
                    if (throwException == true)
                    {
                        throw;
                    }
                    else
                    {
                        // internal reconnect, the reconnect has failed so might as well clean everything and try again
                        _KillTimers();
                        _KillRedisClient();
    
                        // faster than usual reconnect if failure
                        _ReconnectTimer(1000);
                    }
                }
                finally
                {
                    // finished connection attempt, notify everything and remove lock
                    m_Connecting = false;
                    Monitor.Exit(m_ConnectionLocker);
                }
            }
    
            private ConfigurationOptions _CreateRedisConfiguration(CommandMap commandMap, string password, List<RedisConnection> connections)
            {
                ConfigurationOptions connection = new ConfigurationOptions
                {
                    CommandMap = commandMap,
                    AbortOnConnectFail = true,
                    AllowAdmin = true,
                    ConnectTimeout = m_ConnectTimeout,
                    SyncTimeout = m_Timeout,
                    ServiceName = "master",
                    TieBreaker = string.Empty,
                    Password = password,
                };
    
                connections.ForEach(s =>
                {
                    connection.EndPoints.Add(s.Address, s.Port);
                });
    
                return connection;
            }
    
            private void _OutputConfigurationFromSentinel()
            {
                m_SentinelServers.ForEach(s =>
                {
                    try
                    {
                        IServer server = m_Sentinel.GetServer(s.Address, s.Port);
                        if (server.IsConnected == true)
                        {
                            try
                            {
                                IPEndPoint master = server.SentinelGetMasterAddressByName("master") as IPEndPoint;
                                var slaves = server.SentinelSlaves("master");
    
                                StringBuilder sb = new StringBuilder();
                                sb.Append(">>>>>> _OutputConfigurationFromSentinel Server ");
                                sb.Append(s.Address);
                                sb.Append(" thinks that master is ");
                                sb.Append(master);
                                sb.Append(" and slaves are ");
    
                                foreach (var slave in slaves)
                                {
                                    string name = slave.Where(i => i.Key == "name").Single().Value;
                                    bool up = slave.Where(i => i.Key == "flags").Single().Value.Contains("disconnected") == false;
    
                                    sb.Append(name);
                                    sb.Append("(");
                                    sb.Append(up == true ? "connected" : "down");
                                    sb.Append(") ");
                                }
                                sb.Append(">>>>>>");
                                LoggerQueue.Debug(sb.ToString());
                            }
                            catch (Exception ex)
                            {
                                LoggerQueue.Error(string.Format(">>>>>> _OutputConfigurationFromSentinel Could not get configuration from sentinel server ({0}) >>>>>>", s.Address), ex);
                            }
                        }
                        else
                        {
                            LoggerQueue.Error(string.Format(">>>>>> _OutputConfigurationFromSentinel Sentinel server {0} was not connected", s.Address));
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerQueue.Error(string.Format(">>>>>> _OutputConfigurationFromSentinel Could not get IServer from sentinel ({0}) >>>>>>", s.Address), ex);
                    }
                });
            }
    
            private RedisConnection[] _GetAllRedisServersFromSentinel()
            {
                // ask each sentinel server for its configuration
                List<RedisConnection> redisServers = new List<RedisConnection>();
                m_SentinelServers.ForEach(s =>
                {
                    try
                    {
                        IServer server = m_Sentinel.GetServer(s.Address, s.Port);
                        if (server.IsConnected == true)
                        {
                            try
                            {
                                // store master in list
                                IPEndPoint master = server.SentinelGetMasterAddressByName("master") as IPEndPoint;
                                redisServers.Add(new RedisConnection { Address = master.Address.ToString(), Port = master.Port });
    
                                var slaves = server.SentinelSlaves("master");
                                foreach (var slave in slaves)
                                {
                                    string address = slave.Where(i => i.Key == "ip").Single().Value;
                                    string port = slave.Where(i => i.Key == "port").Single().Value;
    
                                    redisServers.Add(new RedisConnection { Address = address, Port = Convert.ToInt32(port) });
                                }
                            }
                            catch (Exception ex)
                            {
                                LoggerQueue.Error(string.Format(">>>>>> _GetAllRedisServersFromSentinel Could not get redis servers from sentinel server ({0}) >>>>>>", s.Address), ex);
                            }
                        }
                        else
                        {
                            LoggerQueue.Error(string.Format(">>>>>> _GetAllRedisServersFromSentinel Sentinel server {0} was not connected", s.Address));
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerQueue.Error(string.Format(">>>>>> _GetAllRedisServersFromSentinel Could not get IServer from sentinel ({0}) >>>>>>", s.Address), ex);
                    }
                });
    
                return redisServers.Distinct().ToArray();
            }
    
            private IServer _GetRedisMasterFromSentinel()
            {
                // ask each sentinel server for its configuration
                foreach (RedisConnection sentinel in m_SentinelServers)
                {
                    IServer sentinelServer = _Sentinel.GetServer(sentinel.Address, sentinel.Port);
                    if (sentinelServer.IsConnected == true)
                    {
                        try
                        {
                            IPEndPoint master = sentinelServer.SentinelGetMasterAddressByName("master") as IPEndPoint;
                            return _Redis.GetServer(master);
                        }
                        catch (Exception ex)
                        {
                            LoggerQueue.Error(string.Format(">>>>>> Could not get redis master from sentinel server ({0}) >>>>>>", sentinel.Address), ex);
                        }
                    }
                }
    
                throw new InvalidOperationException("No sentinel server available to get master");
            }
    
            private void _ReconnectTimer(Nullable<Int32> reconnectMilliseconds)
            {
                try
                {
                    lock (m_ReconnectLocker)
                    {
                        if (m_ReconnectTimer != null)
                        {
                            m_ReconnectTimer.Dispose();
                            m_ReconnectTimer = null;
                        }
    
                        // since a reconnect will definately occur we can stop the check timers for now until reconnect succeeds (where they are recreated)
                        _KillTimers();
    
                        LoggerQueue.Warn(">>>>>> REDIS STARTING RECONNECT TIMER >>>>>>");
    
                        m_ReconnectTimer = new Timer(_Connect, false, reconnectMilliseconds.GetValueOrDefault(m_ReconnectTime), Timeout.Infinite);
                    }
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error("Error during _ReconnectTimer", ex);
                }
            }
    
            private void _CheckSubscriptions(object state)
            {
                if (Monitor.TryEnter(m_ConnectionLocker, TimeSpan.FromSeconds(1)) == false)
                {
                    return;
                }
    
                try
                {
                    DateTime now = DateTime.UtcNow;
                    foreach (RedisSubscription subscription in m_Subscriptions.Values)
                    {
                        if ((now - subscription.LastUsed) > TimeSpan.FromSeconds(subscription.MaxNoReceiveSeconds))
                        {
                            try
                            {
                                EndPoint endpoint = m_Redis.GetSubscriber().IdentifyEndpoint(subscription.Channel);
                                EndPoint subscribedEndpoint = m_Redis.GetSubscriber().SubscribedEndpoint(subscription.Channel);
    
                                LoggerQueue.Warn(string.Format(">>>>>> REDIS Channel '{0}' has not been used for longer than {1}s, IsConnected: {2}, IsConnectedChannel: {3}, EndPoint: {4}, SubscribedEndPoint: {5}, reconnecting...", subscription.Channel, subscription.MaxNoReceiveSeconds, m_Redis.GetSubscriber().IsConnected(), m_Redis.GetSubscriber().IsConnected(subscription.Channel), endpoint != null ? endpoint.ToString() : "null", subscribedEndpoint != null ? subscribedEndpoint.ToString() : "null"));
                            }
                            catch (Exception ex)
                            {
                                LoggerQueue.Error(string.Format(">>>>>> REDIS Error logging out details of Channel '{0}' reconnect", subscription.Channel), ex);
                            }
    
                            _ReconnectTimer(null);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error(">>>>>> REDIS Exception ERROR during _CheckSubscriptions", ex);
                }
                finally
                {
                    Monitor.Exit(m_ConnectionLocker);
                }
            }
    
            private void _CheckWrite(object state)
            {
                if (Monitor.TryEnter(m_ConnectionLocker, TimeSpan.FromSeconds(1)) == false)
                {
                    return;
                }
    
                try
                {
                    this.Database.HashSet(Environment.MachineName + "SmartoddsWriteCheck", m_CheckWriteGuid.ToString(), DateTime.UtcNow.Ticks);
                }
                catch (RedisConnectionNotReadyException)
                {
                    LoggerQueue.Warn(">>>>>> REDIS RedisConnectionNotReadyException ERROR DURING _CheckWrite");
                }
                catch (RedisServerException ex)
                {
                    LoggerQueue.Warn(">>>>>> REDIS RedisServerException ERROR DURING _CheckWrite, reconnecting... - " + ex.Message);
                    _ReconnectTimer(null);
                }
                catch (RedisConnectionException ex)
                {
                    LoggerQueue.Warn(">>>>>> REDIS RedisConnectionException ERROR DURING _CheckWrite, reconnecting... - " + ex.Message);
                    _ReconnectTimer(null);
                }
                catch (TimeoutException ex)
                {
                    LoggerQueue.Warn(">>>>>> REDIS TimeoutException ERROR DURING _CheckWrite - " + ex.Message);
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error(">>>>>> REDIS Exception ERROR during _CheckWrite", ex);
                }
                finally
                {
                    Monitor.Exit(m_ConnectionLocker);
                }
            }
    
            private void _ConnectionFailure(object sender, ConnectionFailedEventArgs e)
            {
                LoggerQueue.Warn(string.Format(">>>>>> REDIS CONNECTION FAILURE, {0}, {1}, {2} >>>>>>", e.ConnectionType, e.EndPoint.ToString(), e.FailureType));
            }
    
            private void _ConnectionRestored(object sender, ConnectionFailedEventArgs e)
            {
                LoggerQueue.Warn(string.Format(">>>>>> REDIS CONNECTION RESTORED, {0}, {1}, {2} >>>>>>", e.ConnectionType, e.EndPoint.ToString(), e.FailureType));
            }
    
            private void _SubscriptionHandler(string channel, RedisValue value)
            {
                // get handler lookup
                RedisSubscription subscription = null;
                if (m_Subscriptions.TryGetValue(channel, out subscription) == false || subscription == null)
                {
                    return;
                }
    
                // update last used
                subscription.LastUsed = DateTime.UtcNow;
    
                // call handler
                subscription.Handler(channel, value);
            }
    
            public Int64 Publish(string channel, RedisValue message)
            {
                try
                {
                    return _Redis.GetSubscriber().Publish(channel, message);
                }
                catch (RedisConnectionNotReadyException)
                {
                    LoggerQueue.Error("REDIS RedisConnectionNotReadyException ERROR DURING Publish");
                    throw;
                }
                catch (RedisServerException ex)
                {
                    LoggerQueue.Error("REDIS RedisServerException ERROR DURING Publish - " + ex.Message);
                    throw;
                }
                catch (RedisConnectionException ex)
                {
                    LoggerQueue.Error("REDIS RedisConnectionException ERROR DURING Publish - " + ex.Message);
                    throw;
                }
                catch (TimeoutException ex)
                {
                    LoggerQueue.Error("REDIS TimeoutException ERROR DURING Publish - " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error("REDIS Exception ERROR DURING Publish", ex);
                    throw;
                }
            }
    
            public bool LockTake(RedisKey key, RedisValue value, TimeSpan expiry)
            {
                return _Execute(() => this.Database.LockTake(key, value, expiry));
            }
    
            public bool LockExtend(RedisKey key, RedisValue value, TimeSpan extension)
            {
                return _Execute(() => this.Database.LockExtend(key, value, extension));
            }
    
            public bool LockRelease(RedisKey key, RedisValue value)
            {
                return _Execute(() => this.Database.LockRelease(key, value));
            }
    
            private void _Execute(Action action)
            {
                try
                {
                    action.Invoke();
                }
                catch (RedisServerException ex)
                {
                    LoggerQueue.Error("REDIS RedisServerException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (RedisConnectionException ex)
                {
                    LoggerQueue.Error("REDIS RedisConnectionException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (TimeoutException ex)
                {
                    LoggerQueue.Error("REDIS TimeoutException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error("REDIS Exception ERROR DURING _Execute", ex);
                    throw;
                }
            }
    
            private TResult _Execute<TResult>(Func<TResult> function)
            {
                try
                {
                    return function.Invoke();
                }
                catch (RedisServerException ex)
                {
                    LoggerQueue.Error("REDIS RedisServerException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (RedisConnectionException ex)
                {
                    LoggerQueue.Error("REDIS RedisConnectionException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (TimeoutException ex)
                {
                    LoggerQueue.Error("REDIS TimeoutException ERROR DURING _Execute - " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error("REDIS ERROR DURING _Execute", ex);
                    throw;
                }
            }
    
            public string[] GetAllKeys(string pattern)
            {
                if (m_Sentinel != null)
                {
                    return _GetAnyRedisSlaveFromSentinel().Keys(m_DatabaseId, pattern).Select(k => (string)k).ToArray();
                }
                else
                {
                    return _Redis.GetServer(_Redis.GetEndPoints().First()).Keys(m_DatabaseId, pattern).Select(k => (string)k).ToArray();
                }
            }
    
            private void _KillSentinelClient()
            {
                try
                {
                    if (m_Sentinel != null)
                    {
                        LoggerQueue.Debug(">>>>>> KILLING SENTINEL CONNECTION >>>>>>");
    
                        ConnectionMultiplexer sentinel = m_Sentinel;
                        m_Sentinel = null;
    
                        sentinel.Close(false);
                        sentinel.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error(">>>>>> Error during _KillSentinelClient", ex);
                }
            }
    
            private void _KillRedisClient()
            {
                try
                {
                    if (m_Redis != null)
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        LoggerQueue.Debug(">>>>>> KILLING REDIS CONNECTION >>>>>>");
    
                        ConnectionMultiplexer redis = m_Redis;
                        m_Redis = null;
    
                        if (this.IsSentinel == true)
                        {
                            redis.ConnectionFailed -= _ConnectionFailure;
                            redis.ConnectionRestored -= _ConnectionRestored;
                        }
    
                        redis.Close(false);
                        redis.Dispose();
    
                        LoggerQueue.Debug(">>>>>> KILLED REDIS CONNECTION >>>>>> " + sw.Elapsed);
                    }
                }
                catch (Exception ex)
                {
                    LoggerQueue.Error(">>>>>> Error during _KillRedisClient", ex);
                }
            }
    
            private void _KillClients()
            {
                lock (m_ConnectionLocker)
                {
                    _KillSentinelClient();
                    _KillRedisClient();
                }
            }
    
            private void _KillTimers()
            {
                if (m_CheckSubscriptionsTimer != null)
                {
                    m_CheckSubscriptionsTimer.Dispose();
                    m_CheckSubscriptionsTimer = null;
                }
                if (m_CheckWriteTimer != null)
                {
                    m_CheckWriteTimer.Dispose();
                    m_CheckWriteTimer = null;
                }
            }
    
            public void Dispose()
            {
                _KillClients();
                _KillTimers();
            }
        }
    }
