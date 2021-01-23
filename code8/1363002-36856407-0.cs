    Add the parameter List<Foo> dynamicList in Run method and pass the List from the caller class constructor A().
    class Foo()
    {
        public Foo(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    class A
    {
        public A()
        {
            this.dynamicList.Add(new Foo(1, "One"));
            this.dynamicList.Add(new Foo(2, "Two"));
            this.dynamicList.Add(new Foo(3, "Three"));
    
            b = B();
            b.Run(dynamicList);
        }
        public List<Foo> dynamicList = new List<Foo>();
    }
    
    class B 
    {
                public void Run(List<Foo> dynamicList)
        {
            while(true)
            {
                int id;
                string name;
    
                var data= dynamicList.FirstOrDefault(x=>x.Id==2);
                id=data.Id;
                //id = 2;
                var two=  dynamicList.FirstOrDefault(x=>x.Id==2).Select(x=>x.Name);
                // I need to convert the value of '2' to 'Two'
    
            }
        }
    }
