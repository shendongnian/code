    public SqlConnection conn;
    public SqlCommand cmd;
    string connstring  = (@"Data Source=SINDALSQL\MSSQL14; Initial Catalog=OminiData; Integrated Security =True");
    string  sql= ("SELECT Mærke, Model, Årgang, [Motor Type], Krydsmål, Centerhul, Møtrik, Bolter, Dæk, Fælge FROM Hjuldata");
    private void binddata()
    {
        DataTable dt = new DataTable();
        using (SqlDataAdapter adp = new SqlDataAdapter(sql,connstring))
        {
            adp.Fill(dt);
            hjuldata.DataContext = dt;
        }
    }
