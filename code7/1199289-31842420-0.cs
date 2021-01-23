            using (StreamReader sr = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/Subfolder/TextFile.txt"))
            {
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
