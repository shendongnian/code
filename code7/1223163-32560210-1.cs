     var link = File.ReadLines(path + "\\text.txt").ToArray();
                foreach (var txt in link)
                {
                    if (txt.Contains("Output="))
                    {
                        var outputPath = txt.Split('=')[1];
                        if (File.Exists(path + "\\text2.txt")) File.AppendAllText(path + "\\text2.txt", outputPath);
                        else
                        {
                            File.AppendAllText(path + "\\text2.txt", "outlog =" + outputPath);
                        }
                    }
                    else if (txt.Contains("Licfile="))
                    {
                        var LicFilePath = txt.Split('=')[1];
                        if (File.Exists(path + "\\text2.txt")) File.AppendAllText(path + "\\text2.txt", LicFilePath);
                        else
                        {
                            File.AppendAllText(path + "\\text2.txt", "outlog =" + LicFilePath);
                        }
                    }
                }
