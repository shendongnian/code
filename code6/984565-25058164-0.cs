    StringBuilder sb = new StringBuilder();
    
    foreach(string line in Lines)
    {
        sb.AppendLine(line);
        //or 
        //sb.AppendFormat("My line: {0}{1}", line, Environment.NewLine);
    }
    textBox2.Text = sb.ToString();
