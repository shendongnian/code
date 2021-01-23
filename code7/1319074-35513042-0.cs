        StringBuilder sb = new StringBuilder();
        foreach(var content in contentList.OrderBy(p=>p.Title)) {
            sb.Append(content.Quicklink);
            sb.Append(" ");
            sb.Append(content.Title);
            sb.Append(Environment.NewLine);
           
        }
        Label1.Text = sb.ToString();
