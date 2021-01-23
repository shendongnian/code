    using System;
    namespace Demo
    {
        public class A
        {
            public string field1 { get; set; }
            public string field2 { get; set; }
            public string field3 { get; set; }
            public string field4 { get; set; }
            public string field5 { get; set; }
            public string field6 { get; set; }
            public string field7 { get; set; }
            public string field8 { get; set; }
            public string anotherA1 { get; set; }
            public string anotherA2 { get; set; }
        }
        public class B
        {
            public string field1 { get; set; }
            public string field2 { get; set; }
            public string field3 { get; set; }
            public string field4 { get; set; }
            public string field5 { get; set; }
            public string field6 { get; set; }
            public string field7 { get; set; }
            public string field8 { get; set; }
            public string anotherB1 { get; set; }
            public string anotherB2 { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A {field1 = "A1", field2 = "A2", field3 = "A3"};
                AutoMapper.Mapper.CreateMap<A, B>();
                B b = AutoMapper.Mapper.Map<B>(a);  // Copies fields from a to b
                Console.WriteLine(b.field1); // Prints "A1"
            }
        }
    }
