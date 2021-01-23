    public DataTable Add_new(params string[] t) {
      if (t.Length != 10) throw new ArgumentsException("The method should be called with 10 parameters.");
      OleDbParameter[] param = new OleDbParameter[10];
      for (int i = 1; i < 11; i++) {
        param[i-1] = new OleDbParameter(i.ToString(), OleDbType.VarChar);
        param[i-1].Value = (t[i - 1]);
      }
      DataTable dt = new DataTable();
      dt = DAL.selectdata("Add_Code", param);
      return dt;
    }
