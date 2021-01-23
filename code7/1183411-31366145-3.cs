    if (!IsPostBack)
    {
        using(SqlConnection con = new SqlConnection(....constringhere...)
        {
            GetProjectMaterials(con);
            GetProjectEquipments(con);
            GetProjectVehicle(con);
            GetProjectContractors(con);
            GetTasks(con,resourceID);
            GetMaterials(con);
            GetEquipments(con);
            GetVehicles(con);
            GetLContractors(con);
        }
    }
