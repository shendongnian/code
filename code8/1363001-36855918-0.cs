    public class Foo()
    {
        public Foo(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class A
    {
        B b = null;
        public A()
        {
            this.dynamicList.Add(new Foo(1, "One"));
            this.dynamicList.Add(new Foo(2, "Two"));
            this.dynamicList.Add(new Foo(3, "Three"));
    
            b =new B();
            b.Run(dynamicList);
        }
        public List<Foo> dynamicList = new List<Foo>();
    }
    
    public class B 
    {
        
        public void Run(List<Foo> DynamicList)
        {
            Foo foo = null;
            while(true)
            {
                foo = DynamicList[0];
                int id = foo.Id;
                string name = foo.Name;
    
                //here you can add your logic..
                // it may be foreach loop or something else..
                //and iterate all List in DynamicList
    
                // some code goes here that gets the value of id 2
                id = 2;
    
                // I need to convert the value of '2' to 'Two'
    
            }
        }
    }
