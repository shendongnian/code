    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        using (FileStream fs = new FileStream(FILEPATH, FileMode.Open))
        {
              while (fs.Position != fs.Length)
              {
                  sb.Append(Convert.ToString(fs.ReadByte(),2));
              }
        }
       Console.WriteLine(sb.ToString());
       Console.ReadKey();
    }
