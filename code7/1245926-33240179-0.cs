    class ABC()
    {
    
    public List<T1> t1 {get;set;};
    public List<T1> t2 {get;set;};
    public List<T1> t3 {get;set;};
    
    }
    
    List<ABC> lstABC = new List<ABC>();
              lstABC = (from A in db.T1
                        join B in db.T2  on A.ID equals B.ID                       
                        join C in db.T3 on B.ID equals C.ID                                                
                        select new ABC
                         {
                           t1=A,
                           t2=B,
                           t3 =C  
                                                 
                         }).ToList(); 
