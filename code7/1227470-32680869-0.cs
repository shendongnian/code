         Dim str As String = "PK_TMX_STORAGE_MANAGEMENT.F_FIND_ID_BY_ADDRESS"
            Dim OracleCMD As OracleCommand = New OracleCommand(str, OracleConn)
            OracleCMD.CommandType = CommandType.StoredProcedure      			
		    DIM ELEMENT_ID as  OracleParameter  = new OracleParameter("ELEMENT_ID",OracleDbType.Int32)
		ELEMENT_ID.Direction = ParameterDirection.ReturnValue
		OracleCMD.Parameters.Add(ELEMENT_ID)
					
		     OracleCMD.Parameters.Add(New OracleParameter("ADDRESS", OracleDbType.VARCHAR2, ParameterDirection.Input)).Value = STORAGE_ADDRESS
			 OracleCMD.Parameters.Add(New OracleParameter("BANK_ID", OracleDbType.Int32 , ParameterDirection.Input)).Value = BANK_ID
						OracleConn.Open()	
			OracleCMD.ExecuteNonQuery()
				    Return System.Convert.ToString(OracleCMD.Parameters("ELEMENT_ID").Value )
			OracleConn.Close()
