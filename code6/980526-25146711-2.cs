    public async Task<TValue> GetAsync(string key, Func<Task<TValue>> missingFunc)
    {
        key = GetKey(key);
        var value = default(TValue);
        try
        {
            var db = _connection.GetDatabase();
            var str = await db.StringGetAsync(key);
            if (!str.IsNullOrEmpty)
            {
                value = _jsonSerializer.Deserialize<TValue>(str);
            }
        }
        catch (RedisConnectionException ex)
        {
            HandleRedisConnectionError(ex);
        }
        catch (Exception ex)
        {
            _logger.Error("Error retrieving item '" + key +
                          "' from Redis cache; falling back to missingFunc(). Error = " + ex);
        }
        if (value == default(TValue))
        {
            present = false;
            value = await missingFunc();
            await PerformAddAsync(key, value);
        }
        return value;
    }
    private void HandleRedisConnectionError(RedisConnectionException ex)
    {
        _logger.Error("Connection error with Redis cache; recreating connection for the next try, and falling back to missingFunc() for this one. Error = " + ex.Message);
        Task.Run(async () =>
        {
            try
            {
                await CreateConnectionAsync();
            }
            catch (Exception genEx)
            {
                _logger.Error("Unable to recreate redis connection (sigh); bailing for now: " + genEx.Message);
            }
        });
    }
    private async Task CreateConnectionAsync()
    {
        if (_attemptingToConnect) return;
        var sw = new StringWriter();
        try
        {
            _attemptingToConnect = true;
            _connection = await ConnectionMultiplexer.ConnectAsync(_redisCs, sw);
        }
        catch (Exception ex)
        {
            _logger.Error("Unable to connect to redis async: " + ex);
            _logger.Debug("internal log: \r\n" + sw);
            throw;
        }
        finally
        {
            _attemptingToConnect = false;
        }
    }
    
