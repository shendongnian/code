	public struct UpdateCaseConveyanceRec
	{
		public int CaseHearingID;
		public string ConvenienceRemarks;
		public bool IsConveyed;
	}
	
	public bool UpdateCasesIsConveyed(IEnumerable<UpdateCaseConveyanceRec> uopdates)
    {
		using (SqlConnection conn = DatabaseConnection.OpenConnection())
		using (SqlCommand cmd = new SqlCommand("UpdateCasesIsConveyed", conn))
		usnig (SqlTransaction trans = conn.BeginTransaction("UpdateCasesIsConveyed"))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			var pID = cmd.Parameters.Add("@pk_CaseHearings_ID", SqlDbType.Int);
			var pConveyed = cmd.Parameters.Add("@IsConveyed", SqlDbType.Bit);
			var pRemarks = cmd.Parameters.Add("@ConvenienceRemarks", SqlDbType.VarChar, -1);
			
			var retStatus = cmd.Parameters.Add("@ReturnStatus", SqlDbType.Bit);
			retStatus.Direction = ParameterDirection.Output;
			
			var retStatusMsg = cmd.Parameters.Add("@ReturnStatusMessage", SqlDbType.VarChar, -1);
			retStatusMsg.Direction = ParameterDirection.Output;
			
			try
			{
				foreach (var row in updates)
				{
					pID.Value = row.CaseHearingID;
					pConveyed.Value = row.IsConveyed;
					pRemarks.Value = row.ConvenienceRemarks;
					
					cmd.ExecuteNonQuery();
					
					if (!Convert.ToBoolean(retStatus))
					{
						trans.Rollback();
						return false;
					}
				}
				
				trans.Commit();
			}
			catch ()
			{
				trans.Rollback();
				throw;
			}
			
			return true;
		}
	}
