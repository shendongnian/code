    string pattern = "(SELECT|INSERT|DELETE|UPDATE|--)"; //ADD HERE THE SQL VERBS YOU NEED
    string[] result = Regex.Split(sqls, pattern).Where(s => s != String.Empty).ToArray<string>();
    for (int i = 0; i < result.Count(); i += 2) 
    {
         if (!result[i].StartsWith("--"))
         {
               Console.WriteLine(result[i] + result[i + 1]);
         }
    }
