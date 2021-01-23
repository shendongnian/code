    String Form_action ="http://\" + Request.Url.Authority+\"/XLEZ/DataHandler/Submit.aspx\"";
    
    while ((line = sr.ReadLine()) != null)
                            {
                            if (line.Contains("form id=\"mainform\""))
                            {
                                index = count;
                            }
                            count++;
                        }
                        sr.Dispose();
                    }
                    if (index != 0)
                    {
                        var lines = File.ReadAllLines(selected_path);
                        int start = lines[index].IndexOf("action");
                        string newLine = lines[index].Substring(0, start + 8) + Form_action + " " + lines[index].Substring(lines[index].IndexOf("method"));
                        lines[index] = newLine;
                        File.WriteAllLines(selected_path, lines);
                    }
