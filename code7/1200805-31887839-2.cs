    public DataTable Add_new(string t1,string t2,string t3,string t4,string t5,string t6,string t7,string t8,string t9,string t10) {
      string[] t = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };
      OleDbParameter[] param = new OleDbParameter[10];
      for (int i = 1; i < 11; i++) {
        param[i-1] = new OleDbParameter(i.ToString(), OleDbType.VarChar);
        param[i-1].Value = (t[i - 1]);
      }
      DataTable dt = new DataTable();
      dt = DAL.selectdata("Add_Code", param);
      return dt;
    }
