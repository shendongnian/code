    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var list = new ArrayList();
                list.Add("Hello");
                list.Add(0);
    
                var types = GetTypes(list);
    
                foreach (var itemType in types)
                {
                    Console.WriteLine(itemType.ToString());
                }
    
                Console.ReadLine();
            }
    
            public static HashSet<Type> GetTypes(IList list)
            {
                var types = new HashSet<Type>();
    
                foreach (var item in list)
                {
                    var newType = item.GetType();
                    if (!types.Contains(newType))
                    {
                        types.Add(newType);
                    }
                }
    
                return types;
            }
        }
    }
