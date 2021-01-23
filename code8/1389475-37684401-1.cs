    class Program
    {
        static void Main(string[] args)
        {
            A obj = new A() { X = "foo", Y = "bar", MyZ ="baz" };
            var f = new BinaryFormatter();
            // When you need serizalize only X and Y:
            f.Context = new StreamingContext(StreamingContextStates.All, new []{ "X", "Y" });
            using (var stm = new FileStream("somefile.bin", FileMode.Create))
            {
                f.Serialize(stm, obj);
            }
            // And deserialize only X and Myz
            f.Context = new StreamingContext(StreamingContextStates.All, new []{ "X", "MyZ" });
            using (var stm = new FileStream("somefile.bin", FileMode.Open))
            {
                A des = f.Deserialize(stm) as A;
            }
        }
    }
