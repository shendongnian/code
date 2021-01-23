    public static class SqlClientExtensions {
    #if __MonoCS__
        private static Dictionary<int, string> _connIds = new Dictionary<int, string>();
    #endif
        public static string GetClientConnectionId(this SqlConnection conn) {
            if(conn == null) {
                return Guid.Empty.ToString();
            }
    #if __MonoCS__
            if(!connIds.ContainsKey(conn.GetHashCode())) {
                connIds.Add(conn.GetHashCode(), Guid.NewGuid().ToString());
            }
            return connIds[conn.GetHashCode()];
    #else
            return conn.ClientConnectionId.ToString();
    #endif
        }
    }
