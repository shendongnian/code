    using(StreamReader oReader = new StreamReader(@"E:\Newfolder\a\test.txt"))
    {
        string sLine;
        while((sLine = oReader.ReadLine())!= null)
        {
              string [] sLineItems = sLine.Split('@');
              for(int i = 0;i < sLineItems.Length; i = i+3)
              {
                   Console.WriteLine("Id:{0}",sLineItems[i]);
                   Console.WriteLine("Name:{0}",sLineItems[i+1]);
                   Console.WriteLine("Address:{0}",sLineItems[i+2]);
              }
        }
    }
