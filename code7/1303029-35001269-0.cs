    public bool DeleteAndAddData(string connString)
		{
			using (OleDbConnection conn = new OleDbConnection(connString))
			{
				OleDbTransaction tran = null;
				try
				{
					conn.Open();
					tran = conn.BeginTransaction();
					OleDbCommand deleteComm = new OleDbCommand("DELETE FROM Table", conn);
					deleteComm.ExecuteNonQuery();
					OleDbCommand reAddComm = new OleDbCommand("INSERT INTO Table VALUES(1, 'blabla', 'etc.'", conn);
					reAddComm.ExecuteNonQuery();
					tran.Commit();
				}
				catch (Exception ex)
				{
					tran.Rollback();
					return false;
				}
			}
			return true;
		}
