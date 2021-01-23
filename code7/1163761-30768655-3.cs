    string text = "{1}[56](17)(20)(13)(14)[895](11)(20)[3](8)(12)(3)[19](1)(2)(13)(7)(6)";
	string[] tokens = text.Split(new Char[] { '}', ']', ')' });
		
    char symbol;
    int value;
    
    Dictionary<int, Dictionary<int, List<int>>> data = new Dictionary<int, Dictionary<int, List<int>>>();
    Dictionary<int, List<int>> items = null;
    List<int> leaves = null;
    
    foreach (string token in tokens) {
       if (token.Length == 0) break;
       symbol = token[0];
       value = Int32.Parse(token.Substring(1));
       switch (symbol) {
       case '{':
         items = new Dictionary<int, List<int>>();
         data.Add(value, items);
         break;
       case '[':
         leaves = new List<int>();
         items.Add(value, leaves);
         break;
       case '(':
         leaves.Add(value);
         break;
       }
    }
    
    foreach (int type in data.Keys)
    {
       Console.WriteLine("Type => {{{0}}}", type);
       Console.WriteLine("\tItems =>");
       items = data[type];
          foreach (int item in items.Keys)
          {
             Console.WriteLine("\t\t[{0}] =>", item);
             leaves = items[item];
          for (int i = 0; i < leaves.Count; i += 1) {
             Console.WriteLine("\t\t\t[{0}] => ({1})", i, leaves[i]);
          }
       }
    }
