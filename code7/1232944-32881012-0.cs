    static void Main()
    {
        string res = getItems.getItemsApi();
        RootElement i = JsonConvert.DeserializeObject<RootElement>(res);
        string json = JsonConvert.SerializeObject(i);
    }
