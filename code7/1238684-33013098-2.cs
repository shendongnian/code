    var sourcePart = @"public class Example 
    {
      	public string Name { get; set; }
    	public string Surname { get; set; }
    	public string Cellphone { get; set; }
    	public string Address { get; set; }
    	public string CompanyName { get; set; }
    	public DateTime CurrentDate { get; set; }
    }";
    
    	var sourceTemplate = @"using System;
    
        @code
    
    ";
    
    var code = sourceTemplate.Replace("@code", sourcePart);
    
    CSharpCodeProvider c = new CSharpCodeProvider();
    
    CompilerParameters cp = new CompilerParameters();
    
    CompilerResults cr = c.CompileAssemblyFromSource(cp, code);
    if (cr.Errors.Count > 0)
    {
    	MessageBox.Show("ERROR: " + cr.Errors[0].ErrorText,
    	    "Error evaluating cs code", MessageBoxButtons.OK,
    		   MessageBoxIcon.Error);
    	return;
    }
    
    var a = cr.CompiledAssembly;
    var type = a.GetTypes().Single();
	string[] propertyNames = type.GetProperties().Select(p => p.Name).ToArray();
