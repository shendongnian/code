    public static class Helper
    {
    	public static TResult LoadFromAnySource<TResult>(this ConfigurationSection section, string serviceBaseUri, string nodeName)
    		where TResult : IDatabaseConfigurable<object, ConfigurationSection>, new()
    	{
    		return default(TResult);
    	}
    }
    
    public class ConfigurationSection { }
    public interface IDatabaseConfigurable<out TContract, out TSection> 
    	where TContract : new()
    	where TSection : ConfigurationSection
    { 
    }
    
    public class DatabaseConfigurable<TContract, TSection> : IDatabaseConfigurable<TContract, TSection>
    	where TContract : new()
    	where TSection : ConfigurationSection
    { 
    }
    
    public class SourceObserverContract { }
    public class SourceObserverSection : ConfigurationSection { } 
