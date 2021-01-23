    public class Bar
    {
        private List<Foo> lst;
    
        public List<Foo> Lst
        {
            get { return lst;}        
        }
    
        public Bar()
        {
            lst = new List<Foo>();
            lst.Add(new Foo { Name = "111" });
            lst.Add(new Foo { Name = "222" });
            lst.Add(new Foo { Name = "333" });
            lst.Add(new Foo { Name = "444" });
            lst.Add(new Foo { Name = "555" });            
        }
    }
