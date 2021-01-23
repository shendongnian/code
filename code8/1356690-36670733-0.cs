    void PopulateDiseases()
    {
        SqlConnection con = new SqlConnection(str_con);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("select disease_id, disease_name from diseases", con);
        sda.Fill(dt);
        foreach (DataListItem item in DataList1.Items)
        {
            CheckBoxList checklist = item.FindControl("chkbxlistDiseases") as CheckBoxList;
            checklist.DataSource = dt;
            checklist.DataBind();
        }
    }
