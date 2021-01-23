    public DataTable GetYourData2(string textquery)
            {
                using (OdbcConnection conn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;Exclusive=No;Collate=Machine;NULL=NO;DELETED=YES;BACKGROUNDFETCH=NO;SourceDB=e:/"))
                    {
                        
                    OdbcDataAdapter ODA = new OdbcDataAdapter();
                
                    OdbcCommand ODC = new OdbcCommand(textquery, conn);
                    ODA.SelectCommand = ODC;  
                    conn.Open();
                    ODA.Fill(YourResultSet);
                    return YourResultSet;   
                }
        }
