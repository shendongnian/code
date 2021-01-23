    private void actOnData(Client client, string[] pks, Action<Client, string> addThing)
    {
        foreach (string pk in pks)
        {
            string data = JObject.Parse(DBUtils.GetData(Constants.DBProcedures.GetProcedures.GetWorkerDetailsByPkid, pk))[Constants.ResponseJson.Data].ToString();
            addThing(client, data);
        }
    }
    private void initClerks(Client client)
    {
        string[] pks = client.ClerksPKS.Trim(',').Split(',');
        actOnData(client,pks,(c,d) => { c.addClerk(JsonConvert.DeserializeObject<Clerk[]>(d)[0]); });
    }
    private void initManagers(Client client)
    {
        string[] pks = client.ManagerPK.Trim(',').Split(',');
        actOnData(client, pks, (c, d) => { c.addManager(JsonConvert.DeserializeObject<Manager[]>(d)[0]); });
    }
