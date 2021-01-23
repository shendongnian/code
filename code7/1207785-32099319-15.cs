    namespace SOMEF
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                var connector = PluginsCatalog.Instance.GetConnector("Primary");
                connector.Identify();
                connector.Run(null, null, null);
            }
        }
    }
