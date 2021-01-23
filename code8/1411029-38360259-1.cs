    var sb = new StringBuilder();
    foreach (string line in memo_autores.Text.Split(Environment.NewLine))
    {
        sb.AppendLine(line);
    }
    report.xrRichText1.Text = sb.ToString();
