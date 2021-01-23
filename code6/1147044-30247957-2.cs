    [WebMethod(true)]
    public void SaveData(string gridInputsJson)
    {
        GridInputRoot grid = JsonConvert.DeserializeObject<GridInputRoot>(gridInputsJson);
    
        foreach (var row in grid)
        {
            // Your row.
            Console.Write("First Name:{0}",row.FirstName);
            Console.Write("Last Name:{0}",row.LastName);
            Console.Write("Telephone:{0}",row.Tel);
        }
    }
