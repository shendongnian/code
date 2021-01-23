    var link = File.ReadLines(path + "\\text.txt").ToArray();
            var sb = new StringBuilder();
            foreach (var txt in link)
            {
                if (txt.Contains("Output="))
                {
                    var outputPath = txt.Split('=')[1];
                    sb.AppendLine(string.Format("outlog = {0}", outputPath));
    
                }
                else if (txt.Contains("Licfile="))
                {
                    var LicFilePath = txt.Split('=')[1];
                    sb.AppendLine(string.Format("license_path = {0}", LicFilePath));
                }
            }
            File.WriteAllText(path + "\\text2.txt",sb.ToString());
