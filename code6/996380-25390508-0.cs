    try
    {
        //Add this couple of lines If you are adding controls dynamically and you need to find a specific control (by name)
        //--->DropDownList ddl = default(DropDownList);
        //--->ddl = (DropDownList)FindControl("DropDownList1");
        System.Data.DataTable subjects = new System.Data.DataTable();
        System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT Id, Name FROM yourTable", "your connection");
        adapter.Fill(subjects);
        DropDownList1.DataSource = subjects;
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "id";
        DropDownList1.DataBind();
    }
    catch (Exception ex)
    {
           // Handle the error
    }
