    public static bool BuildXml()
    {
         using (OleDbCommand buildXml = new OleDbCommand("usp_BUILD_RISKCALC_XML", SOleDbConnection))
         {
              buildXml.CommandType = CommandType.StoredProcedure;
    
              try
              {
                   object value = buildXml.ExecuteScalar();
    
                   string SendXml = Convert.ToString(value);
              }
              catch (Exception ex)
              {
                   WriteLog(ex.Message, 101);
                   return false;
              }
         }
    }
