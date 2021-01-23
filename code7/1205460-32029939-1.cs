    public class bar : Foo
    {
        public int ID { get; set; }
        public Foo baseinstance { get; set;} 
    
        public bar(Foo instance)
        {
            baseinstance = instance; 
        }
    }
