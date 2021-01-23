    using System.Collections.Generic;
    using System.Linq;
    namespace MyNamespace
    {
        class Class1
        {
            public int Code { get; set; }
            public bool IsEditable { get; set; }
        }
        class Class2
        {
            public string Value { get; set; }
        }
        class Program
        {
            static void Main()
            {
                var dictionary = new Dictionary<int, string>
                {
                    {1, "one"}, 
                    {2, "two"}
                    // ...
                };
                var list1 = new List<Class1>();
                // add stuff to list 1
                var list2 = new List<Class2>();
                // add stuff to list 2
                foreach (var pair in dictionary)
                {
                    list1.First(w => w.Code == pair.Key).IsEditable = list2.Any(w1 => w1.Value == pair.Value);
                }
            }
        }
    }
