    class Program
    {
        public class Data
        {
            public string Date;
            public string Person;
            public int Hours;
        }
        
        public static void Main(string[] args)
        {
            var data = new Data[]
            {
                new Data { Date = "21/04/2008", Person = "Sally", Hours= 3 },
                new Data { Date = "21/04/2008", Person = "Sam", Hours = 15 },
                new Data { Date = "22/04/2008", Person = "Sam", Hours = 8 },
                new Data { Date = "22/04/2008", Person = "Sally", Hours = 9 },
            };
            
            var aName = new AssemblyName("DynamicModule");
            var mb = AppDomain.CurrentDomain
                .DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave)
                .DefineDynamicModule(aName.Name, aName.Name + ".dll");
            
            var list = new List<object>();
            foreach (var d in data.GroupBy(d=>d.Date))
            {
                var t = mb.DefineType("T" + d.Key);
                t.DefineField("Date", typeof(string), FieldAttributes.Public);
                foreach (var p in d)
                {
                    t.DefineField(p.Person, typeof(int), FieldAttributes.Public);
                }
                var type = t.CreateType();
                
                object e = Activator.CreateInstance(type, 
                              BindingFlags.CreateInstance, null, null, null);
                t.GetDeclaredField("Date").SetValue(e, d.Key);
                d.ToList().ForEach(dd=>t.GetDeclaredField(dd.Person).SetValue(e, dd.Hours));
                
                list.Add(e);
            }
            
            foreach (var e in list)
            {
                Console.Write("{ ");
                foreach (var f in e.GetType().GetFields().OrderBy(f=>f.Name))
                {
                    Console.Write(string.Format(" {0} = {1} ", f.Name, f.GetValue(e)));
                }
                Console.Write(" }\n");
            }
            
            Console.ReadKey();
        }
    }
