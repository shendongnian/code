    List<Item> itemList = new List<Item>();
    string items = GetJSON(url);
    Dictionary<string, string>[] itemDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(items);
    Item newItem = new Item();
    newmItem.ItemCode = Convert.ToInt32 (itemDictionary["Item_Code"]); 
    // ... and the other properties 
    // then add the object to the list 
    itemList.Add(newItem);
    DropDownList3.DataSource = itemList;
    DropDownList3.DataTextField = "ItemName";
   
    DropDownList3.DataBind();
