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
            var aBuilder = AppDomain.CurrentDomain
                .DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
            var mb = aBuilder.DefineDynamicModule(aName.Name,
                                                  aName.Name + ".dll");
            
            var tb = mb.DefineType("DynamicType", TypeAttributes.Public);
            
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
                object e = Activator.CreateInstance(type, BindingFlags.CreateInstance, null, null, null);
                foreach (var f in t.DeclaredFields)
                {
                    if (f.Name == "Date") {
                        f.SetValue(e, d.Key);
                    }
                    else 
                    {
                        foreach (var ff in d) {
                            if (f.Name == ff.Person) {
                                f.SetValue(e, ff.Hours);
                            }
                        }
                    }
                }
                
                list.Add(e);
            }
            
            foreach (var e in list) {
                Console.Write("{ ");
                var fs = e.GetType().GetFields();
                foreach (var f in fs) {
                    Console.Write(string.Format(" {0} = {1} ", f.Name, f.GetValue(e)));
                }
                Console.Write(" }\n");
            }
            
            Console.ReadKey();
        }
    }
