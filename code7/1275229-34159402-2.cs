    using(var streamReader sr = new StreamReader(files[i]))
    {
        string line;
        while((line = sr.ReadLine()) != null)
        {
              if (line.Contains("setting"))
              {
                  filesContent.Add(line);
              }
        }
    }
