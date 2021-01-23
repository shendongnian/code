    public class PluginReport_Excel : MarshalByRefObject, CommonPluginInterface
    {
        public string GetPluginName()
        {
            return "Foo";
        }
        public PluginType { get { return ePluginType.Excel; } }
    }
