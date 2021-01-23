    crm.List dynamicList = new crm.List()
    {
       Type = true, //True for Dynamic List
       ListName = "Dynamic List", //Name of the List
       CreatedFromCode = 2, //1 For Account; 2 For Contact; 3 For Lead
       Query = fetchXml
    };
