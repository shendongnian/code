        public void ConnectToUnc(string remoteUnc, string userName, string passwrod)
        {
            NETRESOURCE nr = new NETRESOURCE();
            // Disk
            nr.dwType = 0x00000001;
            nr.lpRemoteName = remoteUnc;
            // Try to connect to remote UNC (non-interactive, withod drive mapping)
            int ret = WNetUseConnection(IntPtr.Zero, nr, passwrod, userName, 0, null, null, null);
            if (ret != 0)
            {
                throw new Exception("Error connecting to UNC: " + ret);
            }
            var files = Directory.GetFiles(remoteUnc);
        }
