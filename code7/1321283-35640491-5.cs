    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Xml" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Xml" #>
    <#@ output extension=".cs" #>
    using System.Resources;
    using System.Threading;
    namespace YourNameSpace
    {
        public static class SystemMessagesManager
        {		
	        static ResourceManager rsManager;
            static SystemMessagesManager()
            {
                   //Get the current manager based on the current Culture
                  if (Thread.CurrentThread.CurrentCulture.Name == "fr-FR")
                        rsManager = SystemMessagesFrench.ResourceManager;
                  else if (Thread.CurrentThread.CurrentCulture.Name == "el-GR")
                        rsManager = SystemMessagesGreek.ResourceManager;
                  else
                        rsManager = SystemMessagesEnglish.ResourceManager;
             }
            private static string GetString(string Key)
            {
                  return rsManager.GetString(Key) ?? SystemMessagesEnglish.ResourceManager.GetString(Key);
            }
		    <#foreach(string key in GetKeys()){
	         #>
    public static string <#= key #> { get { return GetString("<#=key#>"); } }
		    <# } #> 		    	
    	}
    }
    <#+ 
    string ResourcesBasePath = @"ResourceStrings.resx";
       
    List<string> keys  = null;
    List<string> GetKeys()
    {	
	    if (keys== null)
   	    {
		    var result = new List<string>();		
		    XmlDocument xml = new XmlDocument();		
		    xml.Load(Host.ResolvePath(ResourcesBasePath));
		    XmlNodeList xnList = xml.SelectNodes("root/data");	
		    foreach (XmlNode xn in xnList)
			     result.Add(xn.Attributes["name"].Value);
		    keys = result;
        }	
	    return keys;	
    } #>
