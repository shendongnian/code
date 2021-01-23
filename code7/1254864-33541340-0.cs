    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal class Program
        {
            public static void Main()
            {
                var names = new Names();
                names.Add(1, "Robin");
                names.Add(1, "Rahul");
                names.Add(1, "Adam");
                names.Add(1, "Akhtar");
                names.Add(2, "Sun");
                names.Add(2, "Mon");
                names.Add(2, "Adam");
                names.Add(3, "a");
                names.Add(3, "a");
                names.Add(3, "c");
                Console.WriteLine("IDs for Adam:");
                foreach (int id in names.IdsOf("Adam"))
                    Console.WriteLine(id);
            }
            public sealed class Names
            {
                readonly MultiValueDictionary<int, string> names = new MultiValueDictionary<int, string>();
                readonly MultiValueDictionary<string, int> lookup = new MultiValueDictionary<string, int>();
                public void Add(int id, string name)
                {
                    names.Add(id, name);
                    lookup.Add(name, id);
                }
                public IEnumerable<int> IdsOf(string name)
                {
                    if (lookup.ContainsKey(name))
                        return lookup[name];
                    else
                        return Enumerable.Empty<int>();
                }
                public IEnumerable<string> NamesOf(int id)
                {
                    if (names.ContainsKey(id))
                        return names[id];
                    else
                        return Enumerable.Empty<string>();
                }
            }
        }
    }
