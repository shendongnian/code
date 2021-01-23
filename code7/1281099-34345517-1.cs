    public VDB_TABLE1()
    {
       public int Id {get; set;}
       public string AnotherValue {get; set;}
       public string FKTable2 {get; set;}
       public VDB_TABLE2 Table2
       {
         get
         {
           int id = Convert.ToInt32(FKTable2);
           return context.VDB_TABLE2.Find(id);
         }
       }
    
       ...do similar for Table3
    }
 
