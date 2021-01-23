    [WebMethod(true)]
    public void SaveData(string gridInputsJson)
    {
        GridInputRoot grid = JsonConvert.DeserializeObject<GridInputRoot>(gridInputsJson);
    
        foreach (var item in grid)
        {
            // Your row.
          
            foreach (var column in item.columns) {
              // Your column.
              
              string field = column.field;
              string val = column.val;
            }
        }
    }
