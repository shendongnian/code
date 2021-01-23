            NpgsqlCommand dbcmd = dbcon.CreateCommand();
			string sql =
				"COPY table_name FROM STDIN;";
			dbcmd.CommandText = sql;
			serializer = new NpgsqlCopySerializer(dbcon);
			copyIn = new NpgsqlCopyIn(dbcmd, dbcon, serializer.ToStream);
			copyIn.Start();
			foreach(...){
				serializer.Add... 
				serializer.EndRow();
				serializer.Flush();
			}
			copyIn.End();
			serializer.Close();
