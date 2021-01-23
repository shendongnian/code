	private void Initialize<T>(Client client, string[] pks)
	{
		foreach (string pk in pks)
		{
	    	string data = JObject.Parse(DBUtils.GetData(Constants.DBProcedures.GetProcedures.GetWorkerDetailsByPkid, pk))[Constants.ResponseJson.Data].ToString();
			client.Add(JsonConvert.DeserializeObject<T[]>(data)[0]);	
        }
	}
    private void initClerks(Client client)
    {
		string[] pks = client.ClerksPKS.Trim(',').Split(',');
		Initialize<Clerk>(client, pks);
	}
	private void initManagers(Client client)
	{
		string[] pks = client.ManagerPK.Trim(',').Split(',');
		Initialize<Manager>(client, pks);			
	}
