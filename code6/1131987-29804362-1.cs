    public string RemoveLastTableRow(HtmlTextWriter writer)
    {
         string[] html = writer.ToString().Split(new string[] { "<tr>" }, StringSplitOptions.None);
         return string.Join("", html.Take(html.Count() - 1));
    }
