    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
    class FooViewModel
    {
        public FooViewModel()
        {
        }
    
        public FooViewModel(Foo foo)
        {
            this.Id= foo.Id;
            this.Name= foo.Name;
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public string NewProperty{ get; set; }
    }
    
