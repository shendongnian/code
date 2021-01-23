    query = "insert into Users (username, password, name)values(@u, @p, @n); set @Id = SCOPE_IDENTITY()";
	insertcmd = new SqlCommand(query, con);
	insertcmd.Parameters.Add(new SqlParameter("u", SqlDbType.NVarChar, 20, "username"));
	insertcmd.Parameters.Add(new SqlParameter("p", SqlDbType.NVarChar, 20, "Password"));
	insertcmd.Parameters.Add(new SqlParameter("n", SqlDbType.NVarChar, 50, "name"));
	SqlParameter Id = new SqlParameter("Id", SqlDbType.Int, 0, "Id");
	Id.Direction = ParameterDirection.Output;
	insertcmd.Parameters.Add(Id);
	da.InsertCommand = insertcmd;
