    <#@ template language="C#" debug="true" hostspecific="true"#>
    <#@ include file="EF.Utility.CS.ttinclude.tt"#>
    <#@ include file="TemplateManager.tt"#>
    <#@import namespace="System.Data.Entity.Design.PluralizationServices" #>
    <#
    	// preamble
    	List<Values> values = TemplateManager.ParseDbContextBuilderFactory();	
    	WriteOutput(code, values, namespaceName);
    	FileManager.Process(); // or something
    #>
    <#+
    //_=_
    public void WriteOutput(CodeGenerationTools code, List<string> values, string namespaceName)
    {
    PopIndent();
    #>
    namespace <#=code.Escape(namespaceName)#>
    {
    	public class OutPutClass
    	{
    		<#+
    		foreach (var value in values)
    		{
    		#>
    		public int <#=code.Escape(value)#> {get; set; }
    		<#
    		} // foreach
    		#>
    	}
    }
    <#
    } // WriteOutput
    #>
