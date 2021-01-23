    var f = new Form();
    f.Controls.Add(new DataGridView
    {
        Name = "g",
        Dock = DockStyle.Fill
    });
    f.Load += (se, ev) =>
    {
        var g = ((Form)se).Controls["g"] as DataGridView;
        g.AutoGenerateColumns = true;
        g.AllowUserToAddRows = false;
        g.DataSource = new List<C1>
        {
            new C1{P1=true, P2="x"},
            new C1{P1=false, P2="y"},
        };
        foreach (DataGridViewRow row in g.Rows)
        {
            if ((bool)row.Cells["P1"].Value == true)
                row.Cells["P2"].ReadOnly = true;
        }
    };
    f.ShowDialog();
