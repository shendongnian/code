       _edit = edit.InnerText.Replace("\n", Environment.NewLine);
                       // _edit = edit.InnerText.Replace("<lt;ref&", "<ref>");
                       // _edit = edit.InnerText.Replace("&lt;/ref>", "</ref>");
                        string[] split = _edit.Split(new[] { "==" }, StringSplitOptions.None);
                        System.IO.Directory.CreateDirectory(path + title);
                        using (StreamWriter sw = new StreamWriter(path + title + "\\" + "مقدمه.txt"))
                        {
                            sw.WriteLine(split[0]);
                        }
                        for (int i = 1; i < split.Length; i += 2)
                        {
                            
                            //split[i].Replace("=", " ");
                            //File.WriteAllText(path + split[i] + ".txt", split[i + 1]);
                            using (StreamWriter sw = new StreamWriter(path + title + "\\" + split[i] + ".txt"))
                            {
                                // Add some text to the file.
                                sw.WriteLine(split[i + 1]);
                            }
                        }
