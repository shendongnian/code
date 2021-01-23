    List<QuarterlySales> list = new List<QuarterlySales>();    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        //populate list
    	list.Add(sales);
    }
    
    //Insure the use of the JSON.Net serializer
    return = Newtonsoft.Json.JsonConvert.SerializeObject(list);
