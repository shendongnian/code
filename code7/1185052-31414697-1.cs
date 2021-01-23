    public class MyClass
    {
        public object Property1;
        public object Property2;
    
        public MyClass(object newProperty1, object newProperty2)
        {
            Property1 = newProperty1;
            Property2 = newProperty2;
        }
    
    }
    public class MyClass2 : MyClass
    {
        public object Property3;
    
        public MyClass2(object newProperty1, object newProperty2, object newProperty3)
                   :base(newProperty1, newProperty2)
        {
            Property3 = newProperty3;
        }
    }
