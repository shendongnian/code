    var list = new List<string>();
    MyMethod(list);
    if(list.Count == 0)   // this one will be false because list now have 1 item
        ....
    
    void MyMethod(List<string> list)
    {
        list.Add("hey!");
    }
