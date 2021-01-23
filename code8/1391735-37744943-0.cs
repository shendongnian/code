     if(!IsPostBack)
     {
    //Here I'm binding the data as in the source without removing any words
       GridView1.DataSource = GetData(); //A sample input for testing, you have get it from your source
       GridView1.DataBind();
     }
      private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Description");
            dt.Columns.Add("Place");
            DataRow _reviewer = dt.NewRow();
            _reviewer["Description"] = "Anuradhapura is a major city in Sri Lanka. It is the capital city of North Central Province, Sri Lanka and the capital of Anuradhapura District";
            _reviewer["Place"] = "Country";
            dt.Rows.Add(_reviewer);
            return dt;
        }
    //In `RowDataBound` I'm doing all the manipulations
       protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (drv["Description"] != DBNull.Value)
                {
                    string description = Convert.ToString(drv["Description"]);
                    e.Row.Cells[0].Text = RemoveUnwanedWords(description);
                }
            } 
        }
    
        public string RemoveUnwanedWords(string description)
        {
            List<string> ignoredWords = new List<string>() { "a", "is", "about", "above", "after", "again", "against", "all", "just", "text", "of", "and", "it", "the" };
            return string.Join(" ", description.Split().Where(words => !ignoredWords.Contains(words, StringComparer.InvariantCultureIgnoreCase)));
        }
