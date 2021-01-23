    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CSharpConsoleApplication.Tests
    {
        class OperatorsOverloadingTest
        {
            public static void Run()
            {
                var list = new List<ParentObject>() { 
                    new ParentObject() { IntegerValue = 1 },
                    new ParentObject() { IntegerValue = 2 },
                    new ParentObject() { Child = new ChildObject() { DoubleValue = 10D } },
                    new ParentObject() { Child = new ChildObject() { DoubleValue = 20D } }
                };
    
                ParentObject pTotal = new ParentObject();
    
                foreach (var p in list)
                    pTotal += p;
    
                Console.WriteLine(pTotal);
            }
        }
    
        public class ParentObject
        {
            public int IntegerValue { get; set; }
    
            public ChildObject Child { get; set; }
            
    
    
            public ParentObject()
            {
                Child = new ChildObject();
            }
    
    
    
            public static ParentObject operator +(ParentObject item1, ParentObject item2)
            {
                var parent = new ParentObject() { IntegerValue = item1.IntegerValue + item2.IntegerValue };
                parent.Child = item1.Child + item2.Child;
    
                return parent;
            }
    
    
    
            public override string ToString()
            {
                return string.Format("IntegerValue={0}, Child={1}", IntegerValue, Child);
            }
        }
    
    
    
        public class ChildObject
        {
            public double DoubleValue { get; set; }
    
            public static ChildObject operator +(ChildObject item1, ChildObject item2)
            {
                return new ChildObject() { DoubleValue = item1.DoubleValue + item2.DoubleValue };
            }
    
    
            public override string ToString()
            {
                return string.Format("DoubleValue={0}", DoubleValue);
            }
        }
    }
