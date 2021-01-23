    private JToken convertTokenToArray(JToken aToken)
    {
        JArray arr = new JArray();            
        List<string> items = JsonConvert.DeserializeObject<List<string>>(aToken.ToString());          
        foreach (var item in items)
        {
            JToken i = item;
            arr.Add(i);
        }
        return arr;
    }
