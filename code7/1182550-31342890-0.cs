        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Contains("XYZ") && !reader.EndOfStream)
                {
                    var nextLine = reader.ReadLine();
                    var pass = "Pass";
                    var date = nextLine.Substring(0, 10);
                    var time = nextLine.Substring(11, 12);
        
                    Console.WriteLine("\n\t" + pass + " Date: {0}\tTime: {1}", date, time);
                }
            }
        }
