    <#@ template debug="true" hostSpecific="true" #>
        <#@ output extension=".cs" #>
        <#@ Assembly Name="System.Core" #>
    
        <#@ import namespace="System" #>
        <#@ import namespace="System.IO" #>
        <#@ import namespace="System.Collections.Generic" #>
    
        <# 
        string path  = @"~\YourProjectPath";
    	List<string> dbFiles = GetDBFilesRecursive(path)
    	#>
    	//Your class code goes here
    	<#+
    	public List<string> GetDBFilesRecursive(string path)
    	{
    			
    		List<string> files = new List<string>();
    		
    		try
    		{
    			string[] fileEntries = Directory.GetFiles(path);
    			foreach (string fileName in fileEntries)
    				files.Add(fileName);
    			string [] subdirectoryEntries = Directory.GetDirectories(path);
    			foreach(string subdirectory in subdirectoryEntries)
    				files.AddRange(GetDBFilesRecursive(subdirectory));
    		}
    		catch(Exception e)
    		{
    			throw new Exception("exception occured in tt gen",e );
    		}
    		return files;
    	}
    #>
