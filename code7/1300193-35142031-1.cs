     public class ConnectionsCache :IConnectionCache
    {
        private readonly Dictionary<Guid, UserConnections> m_UserConnections = new Dictionary<Guid, UserConnections>();
        private readonly Dictionary<Guid,Guid>  m_ConnectionsToUsersMapping = new Dictionary<Guid, Guid>();
        readonly object m_UserLock = new object();
        readonly object m_ConnectionLock = new object();
        #region Public
        public UserConnections this[Guid index] 
            => 
            m_UserConnections.ContainsKey(index)
            ?m_UserConnections[index]:new UserConnections();
        public void Add(Guid userId, Guid connectionId)
        {
            lock (m_UserLock)
            {
                if (m_UserConnections.ContainsKey(userId))
                {
                    if (!m_UserConnections[userId].Contains(connectionId))
                    {
                        m_UserConnections[userId].Add(connectionId);
                    }
                }
                else
                {
                    m_UserConnections.Add(userId, new UserConnections() {connectionId});
                }
            }
            
                lock (m_ConnectionLock)
                {
                    if (m_ConnectionsToUsersMapping.ContainsKey(connectionId))
                    {
                        m_ConnectionsToUsersMapping[connectionId] = userId;
                    }
                    else
                    {
                            m_ConnectionsToUsersMapping.Add(connectionId, userId);
                    }
                }
        }
        public void Remove(Guid connectionId)
        {
            lock (m_ConnectionLock)
            {
                if (!m_ConnectionsToUsersMapping.ContainsKey(connectionId))
                {
                    return;
                }
                var userId = m_ConnectionsToUsersMapping[connectionId];
                m_ConnectionsToUsersMapping.Remove(connectionId);
                m_UserConnections[userId].Remove(connectionId);
            }
            
            
           
        }
