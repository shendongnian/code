                string line = string.Empty;
                using (StreamReader file_r = new System.IO.StreamReader("HasBlankLines.xml"))
                {
                    using (StreamWriter file_w = new System.IO.StreamWriter("NoBlankLines.xml"))
                    {
                        while ((line = file_r.ReadLine()) != null)
                        {
                            if (line.Trim().Length > 0)
                                file_w.WriteLine(line);
                        }
                    }
                }
