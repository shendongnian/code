    void SetDataSource()
    {
        //Copies rows of oroginal data table to a new one based on ordering
        //Then adds a summary row
        //Sets the result as DataSource of grid
        var copy = originalData.DefaultView.ToTable();
        copy.Rows.Add("", originalData.AsEnumerable().Sum(x => x.Field<int>("Value")));
        this.dataGridView1.DataSource = copy;
    }
