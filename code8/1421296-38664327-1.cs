    if (!string.IsNullOrWhiteSpace(searchbox.Value))
    {
        ...
        SqlDataSource1.SelectParameters.Add("devNumber", searchbox.Value);
    }
    else
    {
        SqlDataSource1.SelectCommand = "sp_get_ecr_list"; // Probably already set earlier in your code
        SqlDataSource1.SelectParameters.Clear();
    }
    GridView1.DataBind();
