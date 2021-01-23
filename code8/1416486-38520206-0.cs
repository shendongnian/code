    LayEntity lay = null;
    Using(var context = new DBContext())
    {
       lay = context.LayTable.FirstOrDefault(x=>x.id >1);
      
       if(lay != null)
       {
           lay.Name; // use name here.
       }
    }
