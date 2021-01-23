	var parents = new List<Parent>();
	var children = new List<Child>();
	var connectionString=@"Data Source=.\SQLEXPRESS;Initial Catalog=MyDb;Integrated Security=True";
	using (SqlConnection connection = new SqlConnection(connectionString)) {
		var cmd = connection.CreateCommand();
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.CommandText = "GetParents";
		connection.Open();
		using (var reader = cmd.ExecuteReader())
		{
			while (reader.Read()) 
				parents.Add(new Parent {Id = reader.GetInt32(0), Name = reader.GetString(1) });
				
			reader.NextResult();
			while (reader.Read()) 
				children.Add(new Child {Id = reader.GetInt32(0), ParentId = reader.GetInt32(1), Name = reader.GetString(2) });
		}
	}
			
	var childEnumerator = children.GetEnumerator();
	var child = childEnumerator.MoveNext() ? childEnumerator.Current : null;
	foreach (var parent in parents)
	{
		parent.Children = new List<Child>();
		while (child != null && child.ParentId == parent.Id)
		{
			parent.Children.Add(child);
			child = childEnumerator.MoveNext() ? childEnumerator.Current : null;
		}
	}
