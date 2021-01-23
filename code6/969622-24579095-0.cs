    public object[] GetFiveObjects(Type mytype){
    
        var db = new MyContext();
        return db.Set(mytype).Cast<object>().Take(5).ToArray();
    }
