    // Start a new query string
    SparqlParameterizedString queryString = new SparqlParameterizedString();
    // Set the desired prefix declarations
    queryString.Namespaces.AddNamespace("my", new Uri("http://www.codeproject.com/KB/recipes/n3_notation#"));
    
    // Set the command template
    queryString.CommandText = @"SELECT ?name WHERE 
    { 
      [ a my:spec ; 
        my:preferedby @variable ;  
        my:name ?name ].  
    }";
    // Set your parameter
    queryString.SetUri("variable", new Uri("http://www.codeproject.com/KB/recipes/n3_notation#" + preference));
