    private JToken data = JToken.Parse(@"{""Some"":""JSON""}");
    
    public JToken Data()
    {
       return data.DeepClone();
    }
    
    public JToken Data(string path)
    {
       return data.SelectToken(path).DeepClone();
    }
