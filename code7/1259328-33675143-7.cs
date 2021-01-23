      MyClass test = new MyClass {
        FirstName = "John",
        LastName = "Smith",
      };
      String result = "My Name is " + String.Join(" ", test
        .GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(property => property.CanRead)  // Not necessary
        .Select(property => property.GetValue(test)));
      // My Name is John Smith
      Console.Write(result);
