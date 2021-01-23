    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string folder = e.Row.Cells[1].Text;//Your gridview cell location of that string
                string[] parts = folder.Split('\\');
                List<string> filteredstrings = new List<string>();
                foreach (string part in parts)
                {
                    if (Regex.IsMatch(part, @"\d{8}"))
                    {
                        filteredstrings.Add(part);
                    }
                }
                e.Row.Cells.Add(new TableCell() {Text = string.Join(",", filteredstrings)});// this will give CSV value of your List<string>
    
            }
