    public interface IPluginAccess { }
    public class PluginAccess : IPluginAccess { }
    public interface IPluginProcessor<T>{}
    public class PluginProcessor :  IPluginProcessor<PluginAccess> { }
    public interface IPlugin { }
    public abstract class AbstractPlugin<V, T> : IPlugin
        where V : IPluginAccess
        where T : IPluginProcessor<V>
    { }
    public class BasicPlugin : AbstractPlugin<PluginAccess,PluginProcessor> { }
