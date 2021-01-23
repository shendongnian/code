    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        string filter = "1=1";
        if (this.CheckBoxListGenres.Items.OfType<ListItem>().Any(i => i.Selected))
            filter += String.Format(" AND GenreID IN ({0})'",
                String.Join(",", this.CheckBoxListGenres.Items.OfType<ListItem>()
                    .Where(i => i.Selected).Select(i => i.Value)));
        if (this.TextBoxMovieName.Text != "")
            filter += " AND MovieName LIKE '%" + this.TextBoxMovieName.Text + "%'";
            
        DataTable dataTable = ((DataSet)MediaTypeNames.Application["DataSetMovies"]).Tables[0];
        DataView dataView = new DataView(dataTable);
        dataView.RowFilter = filter;
        DataListMovies.DataSource = dataView;
        DataListMovies.DataBind();
    }
