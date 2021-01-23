    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<Data> data = new List<Data>();
            data.Add(new Data { Id = 1, Sequence = 1, CustomIndex = 0 });
            data.Add(new Data { Id = 2, Sequence = 2, CustomIndex = 0 });
            data.Add(new Data { Id = 3, Sequence = 3, CustomIndex = 2 });
            data.Add(new Data { Id = 4, Sequence = 4, CustomIndex = 1 });
            data.Add(new Data { Id = 5, Sequence = 5, CustomIndex = 0 });
            //List of items where the sequence is what counts
            var itemsToPlaceBySequence = data.Where(x => x.CustomIndex == 0).ToList();
            //List of items where the custom index counts
            var itemsToPlaceByCustomIndex = data.Where(x => x.CustomIndex != 0).OrderBy(x => x.CustomIndex).ToList();
            //Array to hold items
            var dataSlots = new Data[itemsToPlaceBySequence.Count + itemsToPlaceByCustomIndex.Count];
            //Place items by sequence
            foreach(var data1 in itemsToPlaceBySequence) {
                dataSlots[data1.Id - 1] = data1;
            }
            //Find empty data slots and place remaining items in CustomIndex order 
            foreach (var data2 in itemsToPlaceByCustomIndex) {
                var index = dataSlots.ToList().IndexOf(null);
                dataSlots[index] = data2;
            }
            var result = dataSlots.ToList();
            result.ForEach(x => Console.WriteLine(x.Id));
            var discard = Console.ReadKey();
        }
        public class Data
        {
            public int Id { get; set; }
            public int Sequence { get; set; }
            public int CustomIndex { get; set; }
        }
    }
