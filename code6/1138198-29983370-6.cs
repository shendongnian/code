    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        public sealed class Entry
        {
            public readonly string Name;
            public readonly double Number;
            public Entry(string name, double number)
            {
                Name   = name;
                Number = number;
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var list = new List<Entry>
                {
                    new Entry("name1", 0.0158),
                    new Entry("name2", 0.0038),
                    new Entry("name3", 0.0148)
                };
                list.Sort((lhs, rhs) => lhs.Number.CompareTo(rhs.Number));
                // Alternatively if you don't want an in-place sort and you
                // want to keep the original unsorted list, you can create
                // a separate sorted list using Linq like so:
                //
                // var sortedList = list.OrderBy(x => x.Number).ToList();
                foreach (var element in list)
                {
                    Console.WriteLine("Name = {0}, Number = {1}", element.Name, element.Number);
                }
            }
        }
    }
