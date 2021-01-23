                using (StreamReader sr = File.OpenText("Sample.txt"))
                {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (!(s.Contains("Weekend")))
                    {
                        Console.WriteLine(s);
                    }
                    else
                    {
                        sr.Close();
                    }
                }
                }
