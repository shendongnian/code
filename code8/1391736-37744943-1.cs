    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }
    
    private void BindGrid()
    {
        string constr = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ReviewDB;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Description, Place FROM Reviews"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
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
