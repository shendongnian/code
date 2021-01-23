    using ProtoBuf;
    using System;
    
    class Program
    {
        static void Main()
        {
            BaseProto obj = new DesiredProto
            {
                Address = "123 Somewhere",
                DestType = DestinationType.Foo,
                Name = "Marc",
                Owner = "Also Marc",
                VType = VObjectType.A
            };
            BaseProto clone = Serializer.DeepClone(obj);
            DesiredProto typedClone = (DesiredProto)clone;
            Console.WriteLine(typedClone.Address);
            Console.WriteLine(typedClone.DestType);
            Console.WriteLine(typedClone.Name);
            Console.WriteLine(typedClone.Owner);
            Console.WriteLine(typedClone.VType);
        }
    }
    
    public enum DestinationType { Foo } // I just made a guess here
    public enum VObjectType // you said this is an enum
    {
        A, B, C
    }
    class RandomClass1Proto : BaseProto { } // just a dummy type to make it complile
    class RandomClass2Proto : BaseProto { }
    class RandomClass3Proto : BaseProto { }
    
    // omitted: code from the question here
