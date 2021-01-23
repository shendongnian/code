    [WebMethod]
    public static List<ListItem> GetListItems(string value)
    {
    
       //..do stuff
       
       return JsonConvert.SerializeObject(items);
    }
