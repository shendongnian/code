    public class PluginReport_Excel : MarshalByRefObject, CommonPluginInterface
    {
        public string GetPluginName()
        {
            return "Foo";
        }
        public string GetPluginType()
        {
            return this.PluginType.ToString();
        }
        public PluginType { get { return ePluginType.Excel; } }
    }
