    public SqlDataReader ExecuteDataReaderAsync(string connectionString, CommandType cmdType, string spName, params SqlParameter[] cmdParameters) {
            //TODO make async once fixed problem
            var results = new Dictionary<string, object>(); // string=FieldName, object=FieldValue
            using (var conn = new SqlConnection(connectionString)) {
                conn.Open();
                using (var cmd = new SqlCommand(spName, conn)) {
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(cmdParameters);
					using (var rdr = cmd.ExecuteReader(CommandBehavior.Default)) {
						while (rdr.Read()) {
							for (int fieldIndex = 0; fieldIndex < rdr.FieldCount; fieldIndex++) {
								results.Add(rdr.GetName(fieldIndex), rdr.GetValue(fieldIndex));
							}
						}
					}
				}
			}
            return results;
        }
