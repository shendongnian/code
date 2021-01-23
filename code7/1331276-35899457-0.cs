    int[] coll = new int[]{10,9,8,7,6,5,4,3,2,1};
    Parallel.ForEach(coll,
        item=>
        {
           Thread.Sleep(TimeSpan.FromSeconds(item));
           Console.WriteLine(item + "Finished");
        });
