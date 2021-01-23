    public List<SD> this[string index]
    {
       get
         {
           foreach (Obj item in ListObj)
            {
              if (item.p == index)
              return item.sD;
            }
            return new List<SD>();
         }              
     }
