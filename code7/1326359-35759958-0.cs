    static string GenerateCode(CodeStatementCollection statements)
    {
    	var writer = new StringWriter();
    	
    	var compiler = new CSharpCodeProvider();
    	
    	foreach (CodeStatement statement in statements)
    	{
    		compiler.GenerateCodeFromStatement(statement, writer, null);
    	}
    	
    	return writer.ToString();
    }
