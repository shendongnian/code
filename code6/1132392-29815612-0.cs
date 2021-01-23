    public void SetAppRole(SqlConnection ta   public void SetAppRole(SqlConnection ta)
       {
           ta.StateChange += Connection_StateChange;
           if (ta.State==ConnectionState.Open)
           {
               ta.Close();
           }
           ta.Open();
       }
