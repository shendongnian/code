    cmbProjectName.Items.Clear();
    Dictionary<int, string> projectsDictionary = new Dictionary<int, string>();
    if (obds.Tables.Count > 0 && obds.Tables[0].Rows.Count > 0)
    {
        for (int iCount = 0; iCount < obds.Tables[0].Rows.Count; iCount++)
        {
            projectsDictionary.Add(iCount, obds.Tables[0].Rows[iCount]["Project_Name"].ToString());
        }
    }   
    cmbProjectName.DataSource = new BindingSource(projectsDictionary, null);
    cmbProjectName.DisplayMember = "Value";
    cmbProjectName.ValueMember = "Key";
