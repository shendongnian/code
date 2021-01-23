    public List<gerant> getinfogerant()
	{
		List<gerant> gerer = new List<gerant>();
		
		try
		{
			connexion connect = new connexion();
			OleDbCommand cmd = new OleDbCommand();
			
			cmd.Connection = new OleDbConnection(connect.getconnexion());
			cmd.CommandType = CommandType.Text;
			comd.CommandText = "select CIN,NOM,PRENOM,ADRESS_PERSONNEL,NUM_TEL,MAIL,MOBILE,CP_GERANT,VILLE_GERANT,DATE_CIN from GERANT";
			
			connection.Open();
			OleDbDataReader reader = cmd.ExecuteReader();
			
			while(reader.Read())
			{
				gerant g = new gerant();
				if (!reader.IsDBNull(0)) g.CIN = int.Parse(reader.GetValue(0).ToString());
				if (!reader.IsDBNull(1)) g.NOM = reader.GetValue(1).ToString();
				if (!reader.IsDBNull(2)) g.PRENOM = reader.GetValue(2).ToString();
				if (!reader.IsDBNull(3)) g.ADRESS_PERSONNEL = reader.GetValue(3).ToString();
				if (!reader.IsDBNull(4)) g.NUM_TEL = Convert.ToDouble(reader.GetValue(4).ToString());
				if (!reader.IsDBNull(5)) g.MAIL = reader.GetValue(5).ToString();
				if (!reader.IsDBNull(6)) g.MOBILE =Convert.ToDouble(reader.GetValue(6).ToString());
				if (!reader.IsDBNull(7)) g.CP_GERANT = int.Parse(reader.GetValue(7).ToString());
				if (!reader.IsDBNull(8)) g.VILLE_GERANT = reader.GetValue(8).ToString();
				if (!reader.IsDBNull(9)) g.DATE_CIN = Convert.ToDateTime(reader.GetValue(9).ToString());
				gerer.add(g);
			}
			return gerer;
		}
		catch(Exception ex)
		{
			throw ex;
		}
		finally
		{
            reader.Close();
			connection.Close();
		}
	}
