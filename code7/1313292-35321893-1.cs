    MyClass myClass = new MyClass { PropertyName = "Testing 1, 2, 3" };
            
    String template = "The value of PropertyName is '{PropertyName}'";
    var replacements = GetPropertyValues(myClass);
    foreach (var replacement in replacements)
    {
        // Note that you have to double-up the '{' and '}' characters to escape them.
        String token = String.Format("{{{0}}}", replacement.Key);
        Console.WriteLine("Searching for occurrences of '{0}'", token);
        template = template.Replace(token, replacement.Value);
    }
    Console.WriteLine(template);
    // Output:
    // The value of PropertyName is 'Testing 1, 2, 3'   
