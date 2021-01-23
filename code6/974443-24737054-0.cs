    public class Foos : List<Foo>
    {
        public Foos() 
        {
        }
    
        public Foos(List<Foo> otherList) 
           : base(otherList)
        {
        }
    
        public string toJSONString()
        {
            //Do something here
        }
    }
