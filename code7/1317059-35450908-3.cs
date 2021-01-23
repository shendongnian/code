    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            List<Value> list = new List<Value>
            {
                new Value() { Guid = Guid.NewGuid() },
                new Value() { Guid = Guid.NewGuid() },
                new Value() { Guid = Guid.NewGuid() },
                new Value() { Guid = Guid.NewGuid() }
            };
        
            var orderedList = list.OrderBy(i => i).ToList();
            int index = orderedList.BinarySearch(new Value{ Guid = list[2].Guid });
            Console.WriteLine(index);
        }
    }
    public class Value: IComparable<Value>
    {
        public int CompareTo(Value other)
        {
            if(other == null)
            {
                return 1;
            }
            return Guid.CompareTo(other.Guid);
        }
        
        public Guid Guid {get;set;}
        public double Val {get;set;}
    }
