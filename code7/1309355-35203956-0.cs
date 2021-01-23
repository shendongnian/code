        System.IO.TextWriter writer = File.CreateText(filepath);
        StreamReader scenFile = new StreamReader(filepath2);
        while (!scenFile.EndOfStream)
        {   (here will go my do-something-function)
         {
          blah blah
         }
         writer.WriteLine(scenFile.ReadLine().ToString();
         writer.Flush();
        }
       writer.Flush();
       writer.Close();
