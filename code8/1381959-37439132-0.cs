    public int GetHashCode(Order o)
    {
       if (o == null)
       {
          return 0;
       }
       return o.Id.GetHashCode();
    }
