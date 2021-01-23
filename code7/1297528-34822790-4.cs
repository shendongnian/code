    f.Load += (se, ev) =>
    {
        var g = ((Form)se).Controls["g"] as DataGridView;
        g.AutoGenerateColumns = true;
        g.AllowUserToAddRows = false;
        var dt = new DataTable();
        dt.Columns.Add("P1", typeof(bool));
        dt.Columns.Add("P2", typeof(string));
        dt.Rows.Add(true, "x");
        dt.Rows.Add(false, "y");
        g.DataSource = dt;
        foreach (DataGridViewRow row in g.Rows)
        {
            if ((bool)row.Cells["P1"].Value == true)
                row.Cells["P2"].ReadOnly = true;
        }
    };
