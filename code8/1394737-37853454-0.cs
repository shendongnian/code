    da.Fill(ds,"vacation_tbl");
    ds.Tables[0].Columns.Add("cyclechbx", typeof(bool)); // here
    vacGrid.DataSource = ds.Tables[0];
    vacGrid.Columns[2].Visible = false;
    vacGrid.Columns[0].HeaderText = "Vacation Code";
    vacGrid.Columns[0].Width = 100;
    vacGrid.Columns[1].HeaderText = "Vacation Name";
    vacGrid.Columns[1].Width = 100;
    // 3 - the index of the bool column. Change it if necessary.
    vacGrid.Columns[3].HeaderText = "Is Cycled";
    vacGrid.Columns[3].Width = 100;
    vacGrid.Columns[3].Name = "cyclechbx";
    for (int i = 0; i < vacGrid.Rows.Count; i++)
    {
        vacGrid["cyclechbx", i].Value = true;
    }
