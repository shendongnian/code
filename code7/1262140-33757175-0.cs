    using(StreamReader sr = new StreamReader(fs))
    {
         while(!sr.EndOfStream)
         {
             Console.WriteLine(sr.ReadLine());
         }
    }
