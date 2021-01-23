    try
    {
       StreamReader reader = new StreamReader(@"C:\Users\Nate\Desktop\TextFiles\" + input);
       using (reader)
       {
           while (!reader.EndOfStream)
           {
               var line = reader.ReadLine();
               Console.WriteLine(line);
           }
       }
    }
