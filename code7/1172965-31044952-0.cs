           foreach (string file in Directory.EnumerateFiles(location, "*.MAI"))
            {
                foreach (string Line in File.ReadAllLines(file))
                {
                    if (Line.Contains("Sended"))
                    { 
                        //Do your stuff here
                    }
                }
            }
