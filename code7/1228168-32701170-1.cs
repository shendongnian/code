    -using (var fileStream = new FileStream("YOUR FILE", FileMode.Open, FileAccess.Read, FileShare.None))
    {                  
        using (var streamReader = new StreamReader(fileStream))
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
              if(line == "YOUR TEXT")
              {
               // Do the rest
              }
            }
        }
    }
