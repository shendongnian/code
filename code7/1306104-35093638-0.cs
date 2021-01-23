    public void LoadList()
    {
        var table = new System.Data.DataTable("Furnaceno");
        using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnaceDeckConnectionString"].ConnectionString))
        {
            conn.Open();
            using (var cmd = new SqlCommand("SELECT * FROM [Furnace]", conn))
            {
                table.Load(cmd.ExecuteReader());
            }
        }
        FurnID.DataSource = table.DefaultView;
        FurnID.DataValueField = "Furnaceno";
        FurnID.DataTextField = "Furnaceno";
        FurnID.DataBind();
    }
