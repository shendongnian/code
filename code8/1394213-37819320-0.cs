        public Foo MapToFoo(List<string> list)
        {
            var Foo = new Foo();
            var propertyName = "Bar";
            int index = 1;
            foreach (var item in list)
            {
                var property = Foo.GetType().GetProperty(string.Format("{0}{1}", propertyName, index));
                if(property != null)
                {
                    property.SetValue(Foo, item);
                }
                index++;
            }
            return Foo;
        }
