        public System.Data.DataTable GetDataTable(string strSQL, string strInitialCatalog)
		{
			System.Data.DataTable dt = null;
			
			using (System.Data.IDbCommand cmd = this.CreateCommand(strSQL))
			{
				dt = GetDataTable(cmd); //, strInitialCatalog);
			} // End Using cmd
			
			return dt;
		} // End Function GetDataTable
