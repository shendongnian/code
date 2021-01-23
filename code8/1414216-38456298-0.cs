      private TelnetConnection[] m_Connections;
      ...
      m_Connections = new TelnetConnection[50];
      for (var i = 0; i < m_Connections.Length; i++)
      {
        m_Connections[i] = new TelnetConnection(string.Concat("10.10.100.", i), 9090);
      }
      ...
      Parallel.ForEach(m_Connections, conn =>
      {
        bool isAlive = conn.IsHostAlive();
      });
