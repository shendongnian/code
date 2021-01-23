    protected override void Dispose(bool disposing)
    {
      if (ProviderConfig.m_bTraceLevelPublic)
        Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Entry);
      this.m_disposed = true;
      this.m_dataSource = string.Empty;
      this.m_serverVersion = string.Empty;
      try
      {
        bool flag = this.m_connectionState == ConnectionState.Closed && this.m_oracleConnectionImpl == null;
        try
        {
          if (!disposing)
          {
            if (!flag)
            {
              if (OraclePool.m_bPerfNumberOfReclaimedConnections)
                OraclePool.PerformanceCounterIncrement(OraclePerfParams.CounterIndex.NumberOfReclaimedConnections, this.m_oracleConnectionImpl, this.m_oracleConnectionImpl.m_cp);
            }
          }
        }
        catch (Exception ex)
        {
          if (ProviderConfig.m_bTraceLevelPublic)
            Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Error, ex.ToString());
        }
        if (!flag)
        {
          try
          {
            this.Close();
          }
          catch (Exception ex)
          {
            if (ProviderConfig.m_bTraceLevelPublic)
              Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Error, ex.ToString());
          }
        }
        try
        {
          base.Dispose(disposing);
        }
        catch (Exception ex)
        {
          if (ProviderConfig.m_bTraceLevelPublic)
            Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Error, ex.ToString());
        }
        try
        {
          GC.SuppressFinalize((object) this);
        }
        catch (Exception ex)
        {
          if (!ProviderConfig.m_bTraceLevelPublic)
            return;
          Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Error, ex.ToString());
        }
      }
      catch (Exception ex)
      {
        if (!ProviderConfig.m_bTraceLevelPublic)
          return;
        Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Error, ex.ToString());
      }
      finally
      {
        if (ProviderConfig.m_bTraceLevelPublic)
          Trace.Write(OracleTraceLevel.Public, OracleTraceTag.Exit);
      }
    }
