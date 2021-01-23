    public class Mapper
    {
        public Foo MapToFoo(List<string> list)
        {
            var Foo = new Foo();
            var props = typeof(Foo).GetProperties()
                                   .Where(pi => pi.Name.StartsWith("Bar"))
                                   .OrderBy(pi => pi.Name).ToList();
            
            for (int i = 0; i < Math.Min(list.Count, props.Count); i++)
                props[i].SetValue(Foo, list[i]);
            return Foo;
        }
    }
