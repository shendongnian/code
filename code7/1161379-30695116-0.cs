        static void Main(string[] args)
       {
            string[] text =  System.IO.File.ReadAllText(@"D:\check.txt").Split(new
             string[] { System.Environment.NewLine },                                                                                       System.StringSplitOptions.RemoveEmptyEntries);
             List<byte[]> Valinbytes = new List<byte[]>();
             int Valtosplit = 0;
             for (int i = 0; i < text.Length;i++)
              {
                 if (text[i].ToLower().Equals("text3"))
                {
                    Valtosplit = i;
                    break;
                }
            }
            for (int j = Valtosplit; j < text.Length; j++)
            {
                byte[] byteval = Encoding.UTF8.GetBytes(text[j]);
                Valinbytes.Add(byteval);
            }
        }
