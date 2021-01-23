    public VDB_MYVIEWMODEL()
    {
       public int Id {get; set;}
       public string AnotherValue {get; set;}
       public string T2 {get; set;}
       public string T3 {get; set;}
    }
    
    string sSQL "Select VDB_TABLE1.Id, VDB_TABLE1.AnotherValue, VDB_TABLE2.AnotherValue as T2, VDB_TABLE3.AnotherValue as T3 from VDB_TABLE1 left join VDB_TABLE2 on VDB_TABLE1.FKTable2 = VDB_TABLE2.PKTable2 left join VDB_TABLE3 on VDB_TABLE1.FKTable3 = VDB_TABLE3.PKTable3;";
            
    List<VDB_MYVIEWMODEL> Results = context.Database.SqlQuery<VDB_MYVIEWMODEL>(sSql).ToList();
