        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(yourQuery, yourConnection)) {
        
        	using (IDataReader reader = cmd.ExecuteReader) {
        		for (int i = 0; i <= reader.FieldCount; i++) {
        			var name = reader.GetName(i);
        		}
        	}
    }
