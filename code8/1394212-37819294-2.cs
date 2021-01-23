    var mapper = new Mapper();
    var values = new Dictionary<string, String>();
    values["Bar1"] = "A";
    values["Bar2"] = "B";
    values["Bar3"] = "C";
    var foo = mapper.MapToFoo(values);
    ...
    public class Mapper
    {
        public Foo MapToFoo(Dictionary<string, string> values)
        {
            var Foo = new Foo();
            foreach (var item in values)
            {
                var prop = typeof(Foo).GetProperty(item.Key);
                if (prop != null)
                    prop.SetValue(Foo, item.Value);
            }
            
            return Foo;
        }
    }
