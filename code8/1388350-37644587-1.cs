    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Account a = new Account();
                a.Add("My name is John");
                a.Add(10);
    
                Console.WriteLine(a.Get<int>(typeof(int)));
                Console.WriteLine(a.Get<string>(typeof(string)));
                Console.ReadLine();
            }
        }
    
        class Account
        {
            private Dictionary<Type, object> _fields = new Dictionary<Type, object>();
    
            public void Add(object data)
            {
                _fields.Add(data.GetType(), data);
            }
    
            public void Remove(Type type)
            {
                _fields.Remove(type);
            }
    
            public T Get<T>(Type type)
            {
                object data = null;
                if (_fields.TryGetValue(type, out data))
                {
                    return (T)data;
                }
    
                return default(T);
            }
        }
    }
