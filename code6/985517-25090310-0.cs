    class B
    {
        public int a { get; set; }
        public int b { get; set; }
        [JsonProperty("A")]
        public List<A> listOfA { get; set; }
    }
    class A
    {
        public string c { get; set; }
        public string d { get; set; }
    }
    class Program
    {
        public static void main(string[] args)
        {
            string json = @"
            {
                ""a"": 12,
                ""b"": 13,
                ""A"": [
                    {
                        ""c"": ""test"",
                        ""d"": ""test""
                    },
                    {
                        ""c"": ""test2"",
                        ""d"": ""test2""
                    },
                    {
                        ""c"": ""test3"",
                        ""d"": ""test3""
                    }
                ]
            }";
            B testOfB = JsonConvert.DeserializeObject<B>(json);
            Console.WriteLine("a: " + testOfB.a);
            Console.WriteLine("b: " + testOfB.b);
            foreach (A a in testOfB.listOfA)
            {
                Console.WriteLine("c: " + a.c);
                Console.WriteLine("d: " + a.d);
            }
        }
    }
