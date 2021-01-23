    protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            string filter = "";
            int selectedCount = 0;
            for (int i = 0; i < this.CheckBoxListGenres.Items.Count; i++)
                if (this.CheckBoxListGenres.Items[i].Selected)
                    selectedCount++;
            if (selectedCount > 0)
            {
                filter = "GenreID=";
                int n = 0; //Used to determine to which genre the loop has arrived
                for (int i = 0; i < this.CheckBoxListGenres.Items.Count; i++)
                {
                    if (this.CheckBoxListGenres.Items[i].Selected)
                    {
                        if (n > 0 && n < selectedCount)
                            filter += " OR ";
                        filter+="'%"+this.CheckBoxListGenres.Items[i].Value.ToString()+"%'";
                        n++;
    
                    }
                }
    
                if (this.TextBoxMovieName.Text!="")
                    filter += " OR MovieName LIKE '%" + this.TextBoxMovieName.Text + "%'";
                DataTable dataTable = ((DataSet)Application["DataSetMovies"]).Tables[0];
                DataView dataView = new DataView(dataTable);
                filter = Convert.ToString(filter);
                dataView.RowFilter = filter;
                this.DataListMovies.DataSource = dataView;
                this.DataListMovies.DataBind();
            }
        }
