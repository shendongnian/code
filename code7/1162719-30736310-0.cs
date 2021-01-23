    public class ThisIsAnEnum : ISomeInterface {
    
        public Func<double,double,double> ConvertSomething {get;private set;}
    
        public MetricType MetricType {get;private set;}
    
        // Private constructor prevents outside instantiations
        private ThisIsAnEnum(MetricType mt) {
            MetricType = mt;
        }
    
        public static readonly ThisIsAnEnum TypeKilom = new ThisIsAnEnum(MetricType.Kilometer) {
            ConvertSomething = (dbl1, dbl2) => {
                ...
                return res;
            }
        }
    
        public static readonly ThisIsAnEnum TypeMillim = new ThisIsAnEnum(MetricType.Millimeter) {
            ConvertSomething = (dbl1, dbl2) => {
                ...
                return res;
            }
        }
    
    }
