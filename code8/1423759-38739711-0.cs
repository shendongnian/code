    public class MyClass
        {
            public MyClass() { }
            private List<string> texts;
            [DataMember]
            public List<string> Texts
            {
                get
                {
                    return new List<string> { "You got me!" };
                }
                set
                {
                    texts = value;
                    Console.WriteLine("Setting property!");
                }
            }
            [OnDeserialized]
            void OnDeserialized(StreamingContext context)
            {
                texts = Texts;
            }
        }
