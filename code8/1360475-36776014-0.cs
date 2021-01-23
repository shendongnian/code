    public static class InputStreamWrapper
    {
        private static DataReader data;
        public static DataReader InputStream 
        {
            get
            {
                if (data == null)
                {
                    data = new DataReader(Connector.Current.Device.InputStream);
                }
                return data;
            }
        }
    }
