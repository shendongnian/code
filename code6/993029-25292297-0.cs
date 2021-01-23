    public class DestClass
    {
        // Now supplying `null` will result in `Value1` equaling "1"
        public DestClass(int? value1)
        {
            Value1 = value1 ?? 1;
        }
    
        public int? Value1 {get; private set;}
        public int? Value2 {get; set;}
    }
