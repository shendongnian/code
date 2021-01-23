    public static void Dummy()
    {
        var query1 = this.Db.Table1.Select(s => new MyObject() { A = s.Field1, B = s.Field2 });
    
        var query2 = this.Db.Table2.Select(s => new MyObject() { A = s.Field1, B = s.Field2, C = s.Field3 });
    
        var result = query1.Concat(query2);
    }
