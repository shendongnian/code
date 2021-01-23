    public ManagementObjectCollection GetServicesList()
        {
            ManagementObjectCollection ret=new ManagementObjectCollection(); //declaration of the collection
            try
            {
                this.Scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service WHERE Caption LIKE 'xxx%'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.Scope, query);
                ret = searcher.Get();
            }
            catch (COMException ex)
            {
                ServerConnectionFailure?.Invoke(this, null);
            }
            return ret;
        }
