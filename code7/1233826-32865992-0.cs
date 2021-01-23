    private static void readData(ref Dictionary<string, Topic> topics)
        {
            Regex rgxOBJE = new Regex("OBJE [0-9]+ ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex rgxTABL = new Regex("TABL ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex rgxTOPI = new Regex("TOPI ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex rgxMTID = new Regex("MTID ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex rgxMODL = new Regex("MODL ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            foreach (string file in Directory.EnumerateFiles(Path, "*.itf"))
            {
                if (file.IndexOf("itf_merger_result") == -1)
                {
                    Topic currentTopic = null;
                    Table currentTable = null;
                    Object currentObject = null;
                    using (var sr = new StreamReader(file, Encoding.Default))
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        Console.WriteLine(file + " read, parsing ...");
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.IndexOf("OBJE") > -1)
                            {
                                if (currentTable.Name != "Metadata" || currentTable.Objects.Count == 0)
                                {
                                    var obje = new Object(rgxOBJE.Replace(line, ""));
                                    currentObject = obje;
                                    currentTable.Objects.Add(obje);
                                }
                            }
                            else if (line.IndexOf("TABL") > -1)
                            {
                                var name = rgxTABL.Replace(line, "");
                                if (currentTopic.Tables.ContainsKey(name))
                                {
                                    currentTable = currentTopic.Tables[name];
                                }
                                else
                                {
                                    var table = new Table(name);
                                    currentTable = table;
                                    currentTopic.Tables.Add(name, table);
                                }
                            }
                            else if (line.IndexOf("TOPI") > -1)
                            {
                                var name = rgxTOPI.Replace(line, "");
                                if (topics.ContainsKey(name))
                                {
                                    currentTopic = topics[name];
                                }
                                else
                                {
                                    var topic = new Topic(name);
                                    currentTopic = topic;
                                    topics.Add(name, topic);
                                }
                            }
                            else if (line.IndexOf("ETOP") > -1)
                            {
                                currentTopic = null;
                            }
                            else if (line.IndexOf("ETAB") > -1)
                            {
                                currentTable = null;
                            }
                            else if (line.IndexOf("ELIN") > -1)
                            {
                                currentObject = null;
                            }
                            else if (currentTopic != null && currentTable != null && currentObject != null)
                            {
                                currentObject.Data.Add(line);
                            }
                            else if (line.IndexOf("MTID") > -1)
                            {
                                MTID = rgxMTID.Replace(line, "");
                            }
                            else if (line.IndexOf("MODL") > -1)
                            {
                                MODL = rgxMODL.Replace(line, "");
                            }
                        }
                        sw.Stop();
                        Console.WriteLine(file + " parsed in {0}s", sw.ElapsedMilliseconds / 1000.0);
                    }
                }
            }
        }
