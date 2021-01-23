    public class MyClass
    {
        public string Name { get; set; }
        public List<MyClass> Children { get; set; }
        public MyClass(string name)
        {
            Name = name;
            Children = new List<MyClass>();
        }
        public void addChildren(MyClass tt)
        {
            Children.Add(tt);
        }
    }
    
