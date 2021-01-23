		public System.Data.IDbCommand CreateCommand(string strSQL)
		{
			System.Data.IDbCommand idbc = this.m_providerFactory.CreateCommand();
			// idbc.CommandText = string.Format(strSQL, " /* TOP 1 */ ", "OFFSET 0 FETCH NEXT 1 ROWS ONLY");
			idbc.CommandText = strSQL;
            idbc.CommandTimeout = 300;
			return idbc;
		} // End Function CreateCommand
