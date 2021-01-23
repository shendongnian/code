	Parallel.ForEach(NodeList, node => {
	    while(true) {
			try {
				using (NpgsqlConnection conn = new NpgsqlConnection(node.ConnectionString)) {
					conn.Open();
					using (NpgsqlCommand npgQuery = new NpgsqlCommand(node.Query, conn)) {
						using (NpgsqlDataReader reader = npgQuery.ExecuteReader()) {
							while (reader.Read()) {
								//Do stuff
							}
						}
					}
				}
				break; // break out of outer while loop
			} catch (Exception e){
				node.Attempts++;
				if(node.Attempts >= RetryAttempts) {
					throw new Exception("Too many retries");
				}
			}
		}
	});
