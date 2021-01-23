    class Example{
         public int Id{get;set;}
    }
    
    var max = db.Query<Example>("query"); 
