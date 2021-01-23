    public class PointValue
    {
        public float Value { get; set; }
    }
    
    public class PointList<PointValueT> 
        where PointValueT : PointValue, new()
    {
      public void addPointToList(float f)
      {
         // do something to f and then add a new point: 
         mylist.Add(new PointValueT { Value = f });
      }
    }
