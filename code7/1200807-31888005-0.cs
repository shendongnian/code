    public DataTable Add_new(params string[] t)
    {
        OleDbParameter[] param = new OleDbParameter[10];
        for (int i = 0; i <= 10; i++)
        {
            var paramName = String.Format("t{0}", i+1);
            param[i] = new OleDbParameter(paramName, OleDbType.VarChar);
            param[i].Value = (t[i]);
        }
        DataTable dt = new DataTable();
        dt = DAL.selectdata("Add_Code", param);
        return dt;
    }
