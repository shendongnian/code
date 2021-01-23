            protected override void OnStart(string[] args)
            {
                if (host != null)
                {
                    host.Close();
                }
                   HostWcfService();
    
            }
