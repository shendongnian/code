    StringBuilder sb=new StringBuilder();
        foreach (var l in linhas)
        if (l != null)
        {
            sb.AppendLine(l);
        }
    MessageBox.Show(sb.ToString());
