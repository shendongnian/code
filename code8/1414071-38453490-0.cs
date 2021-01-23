    public interface CommonPluginInterface
    {
        string GetPluginName();
        string GetPluginType();
        bool ElaborateReport();
        ePluginType PluginType { get; }
    }
