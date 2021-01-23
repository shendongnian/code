    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    namespace Scratch
    {
        [Serializable]
        class Foo
        {
            public string Bar { get; set; }
        }
        class Program
        {
            static void Main()
            {
                var foo = new Foo() { Bar = "Blah" };
                Console.WriteLine(JsonConvert.SerializeObject(foo, new JsonSerializerSettings()
                    {
                        ContractResolver = new DefaultContractResolver()
                        {
                            IgnoreSerializableAttribute = false
                        }
                    }));
            }
        }
    }
