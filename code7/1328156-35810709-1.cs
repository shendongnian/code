    List<dynamic> list = new List<dynamic>();
    public void AddToList()
    {
        dynamic d1 = new ExpandoObject();
        ((IDictionary<string, object>)d1)[KEY_1] = "Value 1";
        ((IDictionary<string, object>)d1)[KEY_2] = "Value 2";
        list.Add(d1);
    
        dynamic d2 = new ExpandoObject();
        ((IDictionary<string, object>)d2)[KEY_1] = "Value 3";
        ((IDictionary<string, object>)d2)[KEY_2] = "Value 4";
        list.Add(d2);
    
        MyListView.ItemSource = listOfDictionaries;
    }
