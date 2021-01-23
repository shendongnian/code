    string[] lines = System.IO.File.ReadAllLines(@"C:/Users/state.csv");
    foreach (string line in lines)
    {
       string[] values = line.Split(',');
       foreach(var item in values)
          {
             Console.WriteLine(item);
          }
    }
    
