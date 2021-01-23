    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jason\Desktop\Input\test1.csv");
    List<string> Parent = new List<string>();
    List<string> Node = new List<string>();
    foreach (string line in lines)
    {
       string[] values = line.Split(',');
       Parent.Add(values[0]);
       Node.Add(values[1]);
       Console.WriteLine(Parent[0]);
    }
