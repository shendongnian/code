    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Foo 
    {
        public string Name { get; }
        public int Age { get; }
        
        public Foo(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    
    class Test
    {
        static void Main()
        {
            var fooList = new[]
            {
                new Foo("Hans", 12),
                new Foo("Georg", 10),
                 new Foo("Birgit", 40)
            };
            var f = GetOrderStatement<Foo>("Age");
            var ordered = fooList.OrderBy(f);
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Name}: {item.Age}");
            }
        }
        
        private static Func<T, int> GetOrderStatement<T>(string attrName)
        {
            var type = Expression.Parameter(typeof(T), attrName);
            var property = Expression.PropertyOrField(type, attrName);
            return Expression.Lambda<Func<T, int>>(property, type).Compile();
        }
    }
