    public class SR<T>
        {
            public T Result { get; set; }
            public T GetResult()
             {
                return Result;
             }
        }
  
     var result = new SR<Bar>(); or  var result = new SR<List<Bar>>();
