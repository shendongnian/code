    int b = 0;
    using (StreamWriter Writer = new StreamWriter(path_to_textfile.txt"))
    {
      using (StreamReader Reader = new StreamReader(lisfile))
      {
        while ((line = Reader.ReadLine()) != null)
        {
          Match match = Regex.Match(line, @"");//line break symbol between quotes.
          if (match.Success)
          {
            b++;
            if (b == 100000) //I got the count of lines correctly.
            {
              Writer.WriteLine(line);
            }
          }
          else
          {
            //Writer.WriteLine(line);
          }
        }
      }
    }
