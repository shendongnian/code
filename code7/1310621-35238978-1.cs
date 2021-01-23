    interface IFoo
        {
            string Property1 { set; get; }
        }
        class Bar1 : IFoo
        {
            //interface implementations
            public string Property1 { get; set; }
            public string myProperty1 { set; get; }
        }
        class Bar2 : IFoo
        {
            //interface implementations
            public string Property1 { get; set; }
            public string myProperty1 { set; get; }
        }
        //Search the list of objects and access the original values.
        List<IFoo> foos = new List<IFoo>();
            foos.Add(new Bar1
            {
                Property1 = "bar1",
                myProperty1 ="myBar1"
            });
            foos.Add(new Bar1());
            foos.Add(new Bar2());
            foos.Add(new Bar2());
            //Get the objects.
            foreach (var foo in foos)
            {
                //you can access foo directly without knowing the original class.
                var fooProperty = foo.Property1;
                //you have to use reflection to get the original type and its properties and methods
                Type type = foo.GetType();
                foreach (var propertyInfo in type.GetProperties())
                {
                    var propName = propertyInfo.Name;
                    var propValue = propertyInfo.GetValue(foo);
                }
            }
    var result = list.Where(a => a.propertyName);
