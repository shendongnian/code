        class Class1
        {
            public int Age { get; set; }
            public string Family { get; set; }
            public string Name { get; set; }
            public double? d { get; set; }
        }
        [Test]
        public void MyTest()
        {
                Class1 c = new Class1() { Age = 12, Family = "JR", Name = "MAX" };
                foreach (var prop in c.GetType().GetProperties().Where(x => x.PropertyType == typeof(double?)))
                {
                    Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(c));
                    prop.SetValue(c, (double?)null); // set null as you wanted
                }
        }
