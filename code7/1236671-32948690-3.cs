    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class MyClass
        {
            public MyClass(string myString)
            {
                MyString = myString;
            }
            public string MyString { get; private set; }
        }
        internal class Program
        {
            private static void Main()
            {
                var strings = new[]
                {
                    "Profiles",
                    "item1",
                    "item2",
                    "item3",
                    "Profiles",
                    "item1",
                    "item2",
                    "Profiles",
                    "item",
                    "Profiles",
                    "item1",
                    "item2"
                };
                // Make a list of "MyClass" items to demonstrate the use of 'splitBy()'.
                var items = strings.Select(str => new MyClass(str)).ToList();
                var profiles = splitBy("Profiles", items, item=>item.MyString).ToList();
                // Now profiles is a list of items separated into profiles. Print them.
                for (int i = 0; i < profiles.Count; ++i)
                {
                    Console.WriteLine("Profile " + i);
                    for (int j = 0; j < profiles[i].Count; ++j)
                        Console.WriteLine("  " + profiles[i][j].MyString);
                    Console.WriteLine();
                }
            }
            // 'TargetSelector' is a delegate that you use to specify how to get from the class instances
            // the string by which you want to group the items.
            private static IEnumerable<List<T>> splitBy<T>(string target, List<T> data, Func<T, string> targetSelector)
            {
                var group = new List<T>();
                foreach (T item in data)
                {
                    if (targetSelector(item) == target)
                    {
                        if (group.Count > 0)
                        {
                            yield return group;
                            group = new List<T>();
                        }
                    }
                    group.Add(item);
                }
                if (group.Count > 0)
                    yield return group;
            }
        }
    }
