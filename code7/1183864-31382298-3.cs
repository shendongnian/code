    abstract class PluginBase : IPlugin
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        int IPlugin.MyProperty3 { get; set; }
    }
