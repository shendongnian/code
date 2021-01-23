    StreamReader sr=new Streameader("myFile.csv");
    
    List<int> myNumbers=new List<int>();
    using (sr)
    {
      while (!sr.EndOfStream)
       {
          string line=sr.Readline();
          int index=line.LastIndexoF(';');
          string numbers=sr.Substring(index+1,sr.Length-1-index);
          string[] num=numbers.Split(',');
          foreach (string n in num)
          {
            myNUmbers.Add(int.Parse(n));
          }
                
       }
    }
