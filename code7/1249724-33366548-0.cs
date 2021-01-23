    public class Node
    {
        [JsonExtensionData]
        public Dictionary<string, JToken> Context { get; set; }
    }
    public class Example
    {
        public Node Node { get; set; }
    }
    var moduleA = new ModuleA {Foo = "Hello from Module A"};
    var moduleB = new ModuleB { Boo = "Hello from Module B" };
    var node = new Node
            {
                Context = new Dictionary<string, JToken>
                {
                    {"A", JToken.FromObject(moduleA)},
                    {"B", JToken.FromObject(moduleB)}
                }
            };
            var example = new Example {Node = node};           
