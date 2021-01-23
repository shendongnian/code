            using (StreamReader sr = new StreamReader(path)) 
            {
                while (sr.Peek() >= 0) 
                {
                    text = sr.ReadLine();
                    var splits = text.Split (new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                }
            }
