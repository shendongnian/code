    string nom = tbxNom.Text;
    #region Normal
    try
    {
        string content1 = tbxArret.Text;
        string path1 = @"C:\Users\DanyWin\Desktop\CsvOutput\" + nom + ".csv";
        var lines = content1.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => Regex.Replace(line, @"\s+", ";") + ";");
        content1 = String.Join("\n", lines);
        File.WriteAllText(path1, content1);
    }
    catch
    {
        lblInfo.Text = "Erreur";
    }
