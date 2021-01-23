    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace ConsoleApplication1
    {
        class Test
        {
            public Test(double y, string s, int x)
            {
                this.Y = y;
                this.s = s;
                this.X = x;
            }
            public int X;
            public double Y { get; private set; }
            public string Z         
            {
                get
                {
                    return s;
                }
            }
            private string s;
        }
        class Program
        {
            static void Main()
            {
                var test = new Test(1.2345, "12345", 12345);
                test.X = 12345;
                var copy = DeepClone(test);
                Console.WriteLine("X = " + copy.X);
                Console.WriteLine("Y = " + copy.Y);
                Console.WriteLine("Z = " + copy.Z);
            }
            public static T DeepClone<T>(T source)
            {
                var settings = new JsonSerializerSettings {ContractResolver = new MyContractResolver()};
                var serialized = JsonConvert.SerializeObject(source, settings);
                return JsonConvert.DeserializeObject<T>(serialized);
            }
            public class MyContractResolver : DefaultContractResolver
            {
                protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
                {
                    var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                    .Select(p => base.CreateProperty(p, memberSerialization))
                                .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                            .Select(f => base.CreateProperty(f, memberSerialization)))
                                .ToList();
                    props.ForEach(p => { p.Writable = true; p.Readable = true; });
                    return props;
                }
            }
        }
    }
