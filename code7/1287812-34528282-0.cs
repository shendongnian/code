	private void Initialize(Client client, string[] pks)
	{
		foreach (string pk in pks)
		{
	    	string data = JObject.Parse(DBUtils.GetData(Constants.DBProcedures.GetProcedures.GetWorkerDetailsByPkid, pk))[Constants.ResponseJson.Data].ToString();
			client.addManager(JsonConvert.DeserializeObject<Manager[]>(data)[0]);	
        }
	}
    private void initClerks(Client client)
    {
		string[] pks = client.ClerksPKS.Trim(',').Split(',');
		Initialize(client, pks);
	}
	private void initManagers(Client client)
	{
		string[] pks = client.ManagerPK.Trim(',').Split(',');
		Initialize(client, pks);			
	}
