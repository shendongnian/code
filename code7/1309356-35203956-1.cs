        System.IO.TextWriter writer = File.CreateText(filepath);
        StreamReader scenFile = new StreamReader(filepath2);
        int count = 0;
        while (!scenFile.EndOfStream)
        {   (here will go my do-something-function)
         {
          blah blah
         }
         writer.WriteLine(scenFile.ReadLine().ToString();
         count ++;
         if(count == 500000)
         {
             writer.Flush();
             count = 0;
         }
        }
       writer.Flush();
       writer.Close();
