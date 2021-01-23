    List<MyObject> MyList = new List<MyObject>;
    
    private void AddObjects() 
    {
    
        for (int i = 1; i < 99; i++)
        {
            MyObject Mo = New MyObject()
            Mo.Name = "MyName";
            Mo.Age = 30 + ctr;
            MyList.Add(Mo);
        }   
    }
