    List<string> listofstring = { .... };
    List<string> results = new List<string>();
    const string toMatch = "Employee.";
    foreach (string str in listofstring)
    {
       if (str.StartsWith(toMatch))
       {
          results.Add(str.Substring(toMatch.Length));
       }
    }
