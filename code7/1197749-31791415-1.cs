    private class CustomTuple : Tuple<List<string>, DateTime?>
    {
      public CustomTuple(IEnumerable<string> strings, DateTime? time)
    		: base(strings.OrderBy(x => x).ToList(), time)
    	{
    	}
    
      public override bool Equals(object obj)
      {
          if (obj == null || GetType() != obj.GetType())
          {
              return false;
          }
    
          var that = (CustomTuple) obj;
    
          if (Item1 == null && that.Item1 != null || Item1 != null && that.Item1 == null) return false;
          if (Item2 == null && that.Item2 != null || Item2 != null && that.Item2 == null) return false;
    
          if (!Item2.Equals(that.Item2)) return false;
          if (that.Item1.Count != Item1.Count) return false;
          for (int i = 0; i < Item1.Count; i++)
          {
              if (!Item1[i].Equals(that.Item1[i])) return false;
          }
    
          return true;
      }
    
      public override int GetHashCode()
      {
          int hash = 17;
          hash = hash*23 + Item2.GetHashCode();
          return Item1.Aggregate(hash, (current, s) => current*23 + s.GetHashCode());
      }
    }
