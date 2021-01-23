    private DataTable dtF;
    ...
    string SQL = "SELECT PageSection, Indent, Content, SummaryId, "
            + "UserRole, AuthorFirstN, AuthorLastN, LastUpdated FROM FellPage";
    using (var dbCon = new MySqlConnection(MySQLConnStr))
    using (var cmd = new MySqlCommand(SQL, dbCon))
    {
        dbCon.Open();
        dtF = new DataTable();
        dtF.Load(cmd.ExecuteReader());
    }
    // IMPORTANT!!!
    dgv1.AutoGenerateColumns = false;
    dgv1.DataSource = dtF;
