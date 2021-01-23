     public bool Contains(object value)
     {
         return IndexOf(value) != -1;
     }
     public int IndexOf(object value)
     {
         if (value == null)
             throw new ArgumentNullException("value");
         return InnerList.IndexOf(value);
     }
