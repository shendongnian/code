	string name = fi.Name;
	string extn = fi.Extension;
	if(!String.IsNullOrEmpty(name))
	{
		da.InsertCommand.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = name;
		da.InsertCommand.Parameters.Add("@DocumentContent", SqlDbType.VarBinary).Value = documentContent;
		da.InsertCommand.Parameters.Add("@DocumentExt", SqlDbType.VarChar).Value = extn;
		cs.Open();
		da.InsertCommand.ExecuteNonQuery();
		cs.Close();
	}
