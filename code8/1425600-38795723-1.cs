    void Main()
    {
    	Module mod = new Module();
    	
    	mod.Name_De = "name";
    	mod.Name_Fr = "nom";
    	
        // This is the unfortunate nasty bit. I address the property using its name 
        // in a String which is just bad. I don't think there is a way
        // you will be able to address the ".Name" property directly and have
        // it return the localized value through your custom attribute though
    	String localizedValue = mod.GetLocalizedProperty("Name");
    }
    
    
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MultilingualAttribute : Attribute
    {
       public MultilingualAttribute()
       {
           
       }
    }
    
    public static class ModuleExtensions
    {
       public static String GetLocalizedProperty(this Module module, String propName)
       {
       		var type = typeof(Module);
            var propInfo = type.GetProperty(propName);
    		
    		// Make sure the prop really is "Multilingual"
       		if(Attribute.IsDefined(propInfo, typeof(MultilingualAttribute)))
    		{
    			String localizedPropName = propInfo.Name;
    			switch(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant())
       			{
    				case "DE":
                   		localizedPropName += "_De";
    					return type.GetProperty(localizedPropName).GetValue(module, null).ToString();
    				case "FR":
    					localizedPropName += "_Fr";
    					return type.GetProperty(localizedPropName).GetValue(module, null).ToString();
    			}
    		}
    		
    		return String.Empty;
       }
    }
    
    public class Module
    {
    	public String Name_De {get; set;}
    	public String Name_Fr {get; set;}
    	
    	[Multilingual]
    	public String Name {get; set;}
    	
    	public Module()
    	{
    		
    	}
    }
