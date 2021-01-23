    public List<Dictionary<string, object>> ExecuteDataReaderAsync(string connectionString, CommandType cmdType, string spName, params SqlParameter[] cmdParameters) {
            //TODO make async once fixed problem
            var records = new List<Dictionary<string, object>>();
            using (var conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (var cmd = new SqlCommand(spName, conn)) {
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(cmdParameters);
					using (var rdr = cmd.ExecuteReader(CommandBehavior.Default)) {
						while (rdr.Read()) {
						   var record = new Dictionary<string, object>();
                           for (int fieldIndex = 0; fieldIndex < rdr.FieldCount; fieldIndex++) {
                              record.Add(rdr.GetName(fieldIndex), rdr.GetValue(fieldIndex));
                           }
                           records.Add(record);
						}
					}
				}
			}
            return results;
        }
