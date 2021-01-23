    internal class Program
    {
        static void Main(string[] args)
        {
            var foo = ProtoTypeBuilder.CompileResultType("Foo", new[]
            {
                new ProtoField ("A", typeof (int)),
                new ProtoField ("B", typeof (int)),
            });
            var record = ProtoTypeBuilder.CompileResultType("Record", new[]
            {
                new ProtoField ("Integer", typeof (int)),
                new ProtoField ("Number", typeof (double)),
                new ProtoField ("String", typeof (string)),
                new ProtoField ("MyFoo", foo),
            });
            var proto = ProtoBuf.Meta.RuntimeTypeModel.Default.GetSchema(record);
            Console.WriteLine(proto);
        }
    } 
