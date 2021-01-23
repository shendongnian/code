    string query = "INSERT INTO TB_RULE_HISTORY
    (   
    N_RULE_ID,
    N_RULE_VERSION,
    DT_START_DATE,
    DT_END_DATE,
    N_CURRENCY_ID,
    N_VALUE1,
    N_VALUE2,
    N_PERCENTAGE,
    N_MONTHS)
    VALUES(:pRuleId
    ,:pRuleVersion
    ,:pDateTimeStart
    ,:pDateTimeEnd
    ,:pCurrencyId
    ,:pValue1
    ,:pValue2
    ,:pPercentage
    ,:pMonths)";    
    try
    {                
      OracleConnection con= new OracleConnection("Data Source=ANTI01T.world ;User Id=AML_UAT;Password=AML_UAT;");
      con.Open();
      OracleCommand cmd = new OracleCommand();
      cmd.Connection =con;
      cmd.CommandText = query;
      cmd.CommandType = CommandType.Text;
      
      cmd.Parameters.AddWithValue("pRuleId", pRuleId);
      cmd.Parameters.AddWithValue("pRuleVersion", pRuleVersion);
    
      ...
    
      cmd.ExecuteNonQuery();
    }
    catch(Exception ex)
    {
      MessageBox.Show(ex.Message);
    }  
