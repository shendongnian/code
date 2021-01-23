    List<string> listofstring = { .... };
    List<string> results = new List<string>();
    const string toMatch = ".";
    int index = -1;
    foreach (string str in listofstring)
    {
       index = str.IndexOf(toMatch);
       if(index >= 0)
       { 
          results.Add(str.Substring(index + 1));
       }
    }
