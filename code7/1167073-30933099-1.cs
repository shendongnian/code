       if (!datatables.Any())
       {
           MessageBox.Show("Files not found");
       }
	   else
	   {
			using (var con = new SqlConnection())
			{
				con.ConnectionString = @"server=" + serverDB + "; database=" + DB + "; Trusted_Connection=" + trustedConnection + "; user=" + UserDB + "; password=" + PassDB + "";
				foreach (var dt in datatables)
				{
					var bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
					bc.DestinationTableName = "ACC_004";
					bc.BatchSize = dt.Rows.Count;
					bc.WriteToServer(dt);
					bc.Close();
				}
				con.Close();
			}
		}
