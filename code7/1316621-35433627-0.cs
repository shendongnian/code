    ProjectDbConnection dbConnection = new ProjectDbConnection();
    if (dbConnection.Open())
    {
        DataTable survey = dbConnection.GetTable("SELECT * FROM tbl_survey");
        DataTable criteriaClasification = dbConnection.GetTable("SELECT * FROM tbl_criteria_classification");
        DataTable criteriaElement = dbConnection.GetTable("SELECT * FROM tbl_criteria");
        dbConnection.Close();
    }
