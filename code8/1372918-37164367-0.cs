    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jason\Desktop\Input\test1.csv");
    foreach (string line in lines)
    {
       string[] values = line.Split(',');
       foreach(var item in values)
          {
             Console.WriteLine(item);
          }
    }
