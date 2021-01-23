    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<TestItem> items = new List<TestItem>();
            List<TestItem> itemsNonParallel = new List<TestItem>();
    
            items.Add(new TestItem() { Age = 1, Size = 12 });
            items.Add(new TestItem() { Age = 2, Size = 1 });
            items.Add(new TestItem() { Age = 5, Size = 155 });
            items.Add(new TestItem() { Age = 23, Size = 42 });
            items.Add(new TestItem() { Age = 7, Size = 32 });
            items.Add(new TestItem() { Age = 9, Size = 22 });
            items.Add(new TestItem() { Age = 34, Size = 11 });
            items.Add(new TestItem() { Age = 56, Size = 142 });
            items.Add(new TestItem() { Age = 300, Size = 13 });
    
            itemsNonParallel.Add(new TestItem() { Age = 1, Size = 12 });
            itemsNonParallel.Add(new TestItem() { Age = 2, Size = 1 });
            itemsNonParallel.Add(new TestItem() { Age = 5, Size = 155 });
            itemsNonParallel.Add(new TestItem() { Age = 23, Size = 42 });
            itemsNonParallel.Add(new TestItem() { Age = 7, Size = 32 });
            itemsNonParallel.Add(new TestItem() { Age = 9, Size = 22 });
            itemsNonParallel.Add(new TestItem() { Age = 34, Size = 11 });
            itemsNonParallel.Add(new TestItem() { Age = 56, Size = 142 });
            itemsNonParallel.Add(new TestItem() { Age = 300, Size = 13 });
    
            foreach (var item in items.AsParallel().OrderBy(x => x.Age).ThenBy(x => x.Size))
            {
                Console.WriteLine($"Age: {item.Age}     Size: {item.Size}");
            }
    
            Console.WriteLine("---------------------------");
    
            foreach (var item in itemsNonParallel.OrderBy(x => x.Age).ThenBy(x => x.Size))
            {
                Console.WriteLine($"Age: {item.Age}     Size: {item.Size}");
            }
    
            Console.ReadLine();        
        }
    }
    
    public class TestItem
    {
        public int Age { get; set; }
        public int Size { get; set; }
    }
