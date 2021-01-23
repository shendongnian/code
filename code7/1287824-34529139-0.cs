    void Init<T>(Client client, Func<Client, string> getPKS, Action<Client, T> addItem)
    {
        string[] pks = getPKS(client).Trim(','). Split(',');
        foreach (string pk in pks)
        {
            string data = JObject.Parse(DBUtils.GetData(Constants.DBProcedures.GetProcedures.GetWorkerDetailsByPkid, pk))[Constants.ResponseJson.Data].ToString();
            addItem(client, JsonConvert.DeserializeObject<T[]>(data)[0]);
        }
    }
