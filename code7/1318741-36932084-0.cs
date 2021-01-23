    // For the first line: string FileName = string.Empty;
    var declareVariableFileName = new CodeVariableDeclarationStatement(                 // Declaring a variable.
        typeof(string),                                                                 // Type of variable to declare.
        "FileName",                                                                     // Name for the new variable.
        new CodePropertyReferenceExpression(                                            // Initialising with a property.
            new CodeTypeReferenceExpression(typeof(string)), "Empty"));                 // Identifying the property to invoke.
    
    // For the second line: FileName = System.IO.Path.GetFileName(file1);
    var assignGetFileName = new CodeAssignStatement(                                    // Assigning a value to a variable.
        new CodeVariableReferenceExpression("FileName"),                                // Identifying the variable to assign to.
        new CodeMethodInvokeExpression(                                                 // Assigning from a method return.
            new CodeMethodReferenceExpression(                                          // Identifying the class.
                new CodeTypeReferenceExpression(typeof(Path)),                          // Class to invoke method on.
                "GetFileName"),                                                         // Name of the method to invoke.
            new CodeExpression[] { new CodeVariableReferenceExpression("file1") }));    // Single parameter identifying a variable.
    
    string sourceCode;
    
    using (StringWriter writer = new StringWriter())
    {
        var csProvider = CodeDomProvider.CreateProvider("CSharp");
        csProvider.GenerateCodeFromStatement(declareVariableFileName, writer, null);
        csProvider.GenerateCodeFromStatement(assignGetFileName, writer, null);
    
        sourceCode = writer.ToString();
    
        // sourceCode will now be...
        // string FileName = string.Empty;
        // FileName = System.IO.Path.GetFileName(file1);
    }
