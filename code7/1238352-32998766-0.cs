    Class Class_Name
    {
         public void Start(string val1,string val2)
          {
              guid; //for unique id for each session,
              hastable and its values;
               HttpContext.Current.Session[guid]=hastable_values;
           }
       public void End()
          {
           hastable t=(hastable)  HttpContext.Current.Session[guid]; //here is the problem,its null.
    
           send the hastable data to database;
    
          }
      }
