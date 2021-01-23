    object value = SomeFunction();
    if( value.GetType().IsArray )
    {
      try
      {
         List<object> l = new List<object>();
         foreach(object o in (IEnumerable)value)
         {
            l.Add(o);
         }
      }
      catch(Exception e)
      {
        //here its failing because its no an object
      }
    }
