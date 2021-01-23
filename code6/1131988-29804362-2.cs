    public string RemoveLastTableRow(HtmlTextWriter writer)
    {
         // Create an array which contains each table row split
         string[] html = writer.ToString().Split(new string[] { "<tr>" }, StringSplitOptions.None);
         
         // Return all the array indexes joined, except for the final index
         return string.Join("", html.Take(html.Count() - 1)); 
    }
