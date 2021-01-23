    string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; 
    using(var connection = new SqlConnection(connectionString))
    {
        var dataTable = new DataTable();
        connection.Open();
        
        var commandText = "SELECT * FROM gender";
        using(var command = new SqlCommand(commandText,connection))
        {
            ddlmarrital.DataSource = command.ExecuteReader();
            ddlmarrital.DataTextField = "field";       
            ddlmarrital.DataValueField = "ID";  
            ddlmarrital.DataBind();         
        }
    }
 
