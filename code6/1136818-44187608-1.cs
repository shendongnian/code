    <#@ template debug="true" hostSpecific="true" #>
    <#@ output extension=".txt" #>
    <#@ assembly Name="System.Core" #>
    <#@ assembly name="EnvDte" #>
    <#@ assembly name="EnvDte80" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections.Generic" #> 
    <#@ import namespace="EnvDTE" #> 
    <#@ import namespace="EnvDTE80" #> 
    <#    
    var env = (this.Host as IServiceProvider).GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
    var project = env.Solution.FindProjectItem(this.Host.TemplateFile).ContainingProject
        as EnvDTE.Project;
    var codeClass = project.ProjectItems.Item("Program.cs").FileCodeModel.CodeElements
                           .OfType<CodeNamespace>().ToList()[0]
                           .Members.OfType<CodeClass>().ToList()[0];
    var attribute = codeClass.Attributes.Cast<CodeAttribute>()
                             .Where(a=>a.Name=="MySample").FirstOrDefault();
    if(attribute!=null)
    {
        var property = attribute.Children.OfType<CodeAttributeArgument>()
                                .Where(a=>a.Name=="Property1").FirstOrDefault();
    	if(property!=null)
    	{
    		var value = property.Value;
    	    WriteLine(value);
    	}
    }
    #>
