    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var child = new Child();
                var serializesObject = JsonConvert.SerializeObject(child);
    
                var deserializedObject = JsonConvert.DeserializeObject(serializesObject, typeof(Child));
            }        
        }
    
        public abstract class Abstract
        {
            public int Prop1 { get; set; }
            public readonly string Prop2;
            public List<string> Prop3 { get; set; }
            public int[] Prop4 { get; set; }
    
            public abstract void Hey();
    
            public Abstract()
            {
                Prop1 = 1;
                Prop2 = "2";
                Prop3 = new List<string>();
                Prop4 = new int[4];
            }
        }
    
        public class Child : Abstract
        {
            public readonly string Prop5;
    
            public Child()
            {
                Prop5 = "5";
    
            }
            public override void Hey()
            {
                throw new NotImplementedException();
            }
        }
    }
