    int extraDataCount = 0;
    string id = Configuration[GetId(extraDataCount)];
    string description = Configuration[GetDescription(extraDataCount)];
    
    var extraDataList = new List<MyID>();
    while(id != null && description != null)
    {
        extraDataList.Add(new MyID { ID = id, Description = description });
        extraDataCount++;
        id = Configuration[GetId(extraDataCount)];
        description = Configuration[GetDescription(extraDataCount)];
    }
    
    private string GetId(int extraDataCount)
    {
        return "ExtraData:" + extraDataCount + ":Id";
    }
    
    private string GetDescription(int extraDataCount)
    {
        return "ExtraData:" + extraDataCount + ":Description";
    }
