    using System;
    using FileHelpers;
    using FileHelpers.Dynamic;
    using System.Data;
    using NUnit.Framework;
    
    namespace OtherNameSpace
    {
        public class MyConverter : ConverterBase
        {
            public override object StringToField(string from)
            {
                return from;
            }
        }
    
    }
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main(string[] args)
            {
                var cb = new DelimitedClassBuilder("Customer", ",");
    
                cb.AddField("SomeField", typeof(String));
                cb.LastField.Converter.TypeName = typeof(OtherNameSpace.MyConverter).ToString();
    
                Type recordClass = cb.CreateRecordClass();
    
                var engine = new FileHelperEngine(recordClass);
                var records = engine.ReadStringAsDT("aaa");
    
                Assert.AreEqual("aaa", records.Rows[0].Field<string>(0));
    
                Console.WriteLine("All OK");
                Console.ReadKey();
            }
        }
    }
