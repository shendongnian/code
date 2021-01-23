    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        using (FileStream fs = new FileStream(InputFILEPATH, FileMode.Open))
        {
              while (fs.Position != fs.Length)
              {
                  sb.Append(Convert.ToString(fs.ReadByte(),2));
              }
        }
        using (StreamWriter stw = new StreamWriter(File.Open(OutputFILEPATH,FileMode.OpenOrCreate)))
        {
                stw.WriteLine(sb.ToString());
        }
       Console.ReadKey();
    }
