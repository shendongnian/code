    Con.Open();
    Cmd.CommandText = SqlCommand;
    SqlDataReader Reader = Cmd.ExecuteReader();
    List<object[]> Ret = new List<object[]>();
    int Columns = Reader.FieldCount;
    while (Reader.Read())
    {
    	object[] RetItem = new object[Columns];
    	for (int i = 0; i < Columns; i++)
    	{
    		RetItem[i] = Reader[i];
    	}
    	Ret.Add(RetItem);
    }
    Reader.Close();
    Con.Close();
