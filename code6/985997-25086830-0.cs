    public Version ServerVersion 
    {
        get
        {
            // Mono doesn't like selecting SERVERPROPERTY, at least not from SQL 2012
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                return new Version(1, 0);
            }
            if (m_version == null)
            {
                var v = this.ExecuteScalar("SELECT  SERVERPROPERTY('productversion')");
                m_version = new Version(v.ToString());
            }
            return m_version;
        }
    }
