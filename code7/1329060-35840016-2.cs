    [HttpPost]
    public ActionResult Save_Data(string rosterArray, int Pricelist_Id, int Group_Id)
    {
        string [][] convertedArray = JsonConvert.DeserializeObject<string [][]>(rosterArray);
    }
