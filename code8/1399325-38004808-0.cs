    public void validNavLeft()
    {
        string validHull = "", validMooring = "";
        comm = new SqlCommand("SELECT * FROM dbo.StructureCurrent", conn);
        conn.Open();
        reader = comm.ExecuteReader();
        while (reader.Read())
        {
            validHull = reader["StructureHull"].ToString();
            validMooring = reader["StructureMooring"].ToString();
        }
        var pageHandler = HttpContext.Current.CurrentHandler;
        Control ctrlHull = ((Page)pageHandler).Master.FindControl("imgbtnHull");
        ImageButton imgBtnHull = (ImageButton)ctrlHull;
        Control ctrlMooring = ((Page)pageHandler).Master.FindControl("imgbtnMooring");
        ImageButton imgBtnMooring = (ImageButton)ctrlMooring;
        switch (validHull)
        {
            case "YES":
                imgBtnHull.Enabled = true;
                imgBtnHull.ImageUrl = "~/Item/RibbonIcon/Dashboard.png";
                break;
            case "NO":
                imgBtnHull.Enabled = false;
                imgBtnHull.ImageUrl = "~/Item/RibbonIcon - Grey/DashboardGrey.png";
                break;
            default:
                break;
        }
        switch (validMooring)
        {
            case "YES":
                imgBtnMooring.Enabled = true;
                imgBtnMooring.ImageUrl = "~/Item/RibbonIcon/Dashboard.png";
                break;
            case "NO":
                imgBtnMooring.Enabled = false;
                imgBtnMooring.ImageUrl = "~/Item/RibbonIcon - Grey/DashboardGrey.png";
                break;
            default:
                break;
        }
    }
