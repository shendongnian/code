    using (var cmd = ctx.Database.Connection.CreateCommand()) {
        ctx.Database.Connection.Open();
        cmd.CommandText = ...; // Your big SQL goes here
    	using (var reader = cmd.ExecuteReader()) {
            return Read(reader).ToList();
        }
    }
