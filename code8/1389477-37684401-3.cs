    class Program
    {
        static void Main(string[] args)
        {
            A obj = new A() { X = "foo", Y = "bar", MyZ = "baz" };
            var f = new BinaryFormatter();
            // Serialize depending on a TemplateEnum param.
            f.Context = new StreamingContext(StreamingContextStates.All, TemplatesEnum.Template1);
            using (var stm = new FileStream("somefile.bin", FileMode.Create))
            {
                f.Serialize(stm, obj);
            }
            // Deserialize
            using (var stm = new FileStream("somefile.bin", FileMode.Open))
            {
                A des = f.Deserialize(stm) as A;
            }
        }
    }
