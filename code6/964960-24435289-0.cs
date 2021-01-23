    public abstract class ValueClass
    {
        protected abstract List<ValuePair> Values { get; }
    
        public decimal? Get(int? key)
        {
            var _result = Values.Where(i => i.Key == key).FirstOrDefault();
            return _result != null ? _result.Value : (decimal?)null;
        }
    }
    
    public class ClassA : ValueClass
    {
        protected override List<ValuePair> Values
        {
            get { return new List<ValuePair>(){    
                new ValuePair(){Key= 1, Value= 50M},    
                new ValuePair(){Key= 2, Value= 100M}
            };
         }
       }
    }
    
    public class ClassB : ValueClass
    {
        protected override List<ValuePair> Values 
        { 
            get { return new List<ValuePair>(){   
                 new ValuePair(){Key= 1, Value= 999999999M},             
                new ValuePair(){Key= 2, Value= 25M}             
            };
        }
      }
    }
