    var sb = new StringBuilder();
    foreach (string line in memo_autores.Text.Split(new [] { Environment.NewLine }, StringSplitOptions.None))
    {
        sb.AppendLine(line);
    }
    report.xrRichText1.Text = sb.ToString();
