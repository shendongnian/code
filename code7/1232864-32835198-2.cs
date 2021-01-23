    List<MyCustom> listofobj = new List<MyCustom>();
    List<MyCustom> templist = new List<MyCustom>();
    foreach(var obj in listofobj)
    {
        if(obj.Age > 30)
        {
            templist.Add(obj); 
        }
    }
