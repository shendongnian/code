    public string getId()
    {
        string result;
        QueryModel Query = new QueryModel();
        string[] fullName = Full_name.Replace("'", "''").Split(' ');
        string fullNameSQL = "";
        for (int i = 0; i < fullName.Count() - 1; i++)
        {
            string fn = "Full_Name LIKE '%" + fullName[i] + "%' ";
            fullNameSQL = (fullNameSQL == "") ? fn : " AND " + fn;
        }
        string sql = "SELECT Username_Id FROM USERNAME WHERE " + fullNameSQL;
        result = Query.ExecuteCommand(sql, "int");
        return result;
    }
