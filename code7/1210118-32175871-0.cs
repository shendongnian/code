		List<string[]> words1 = new List<string[]>();
		string[] stopWords = File.ReadAllLines(@"C:\Users\~\Desktop\stopWords_E_Unique_Spaces.txt");
		Using(SqlConnection con = new SqlConnection("Data Source=Source_Name;Initial Catalog=subset_aminer;Integrated Security=True"))
		{
			con.Open();
			using (SqlCommand query = con.CreateCommand())
			{
			 query.CommandText = "select p_abstract from sub_aminer_paper where aid = 52883";
			 SqlDataReader reader = query.ExecuteReader();			
			 while (reader.Read())
			 {
			     string[] ListElements = new string[2];
			     ListElements[0]=reader["p_abstract"].ToString();
				 ListElements[1]=reader["p_abstract"].ToString() ;
			     words1.Add(ListElements);				
			 }
			}
		}
		reader.Close();
	} 
	for  (int index = 0;	index<words1.Count ; index ++ ) 
	{ 
		foreach  (string word in  stopWords ) 
		{
		     var item = words1.ElementAt(index);
		     item[1] =  item[1].ToString ( ).ToLower().Replace(word,  " " ).Trim();
	         item[1] =  Regex.Replace (item[1].ToString ( ) ,  @"\s+" ,  " " ) ; 
	    } 
	} 
	using(SQLConnection con = new SQLConnection("Data Source=Source_Name;Initial Catalog=subset_aminer;Integrated Security=True")) 
	{
	  con.Open( ) ; 
	  using(SQLCommand command = new SQLCommand(con) )
	  { 
	    for (int i = 0;i<words1.Count ; i++ )
	    {
	    var item = words1.ElementAt(i);
        var itemKey = item[0].ToString();
        var itemValue = item[1].ToString();
        command.CommandText =  string.Format( "UPDATE table1 SET p_abstract_SWR=@newvalue where p_abstract=@oldvalue");
        command.Parameters.AddWithValue( "@newvalue" , itemValue ) ; 
		command.Parameters.AddWithValue( "@oldvalue" , itemKey ); 
	    command.ExecuteNonQuery ( ) ;
	    } 
	  }
	 con.Close ( ) ;
	} 
