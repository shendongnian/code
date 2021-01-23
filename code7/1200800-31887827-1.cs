    public DataTable Add_new(List<String> T) {
    
      OleDbParameter[] param = new OleDbParameter[10];
    
      for (int i = 1; i < 11; i++) {
        param[i-1] = new OleDbParameter(i.ToString(), OleDbType.VarChar);
        param[i-1].Value = (T[i]);
      }
      DataTable dt = new DataTable();
      dt = DAL.selectdata("Add_Code", param);
      return dt;
    }
