    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ include file="CodeGenHelpers.ttinclude" #>
    var regenHelper = new CodeGenHelpers(Host);
    regenHelper.SetupBinPathAssemblyResolution();
    
    if (regenHelper.ShouldRegenerate() == false)
    {
    	Debug.WriteLine($"Not Regenerating File");
    	var existingFileName = Path.ChangeExtension(Host.TemplateFile, "cs"); 
    	var fileContent = File.ReadAllText(existingFileName);
    	return fileContent;
    }
    Debug.WriteLine($"Regenerating File");
    // ...rest of T4
