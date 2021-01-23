    var lists = new List<IList<int>> {
        new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 
        new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },  
        new List<int> { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 }
    };
    var iter = new DataIterator<int>(lists);
    foreach (var items in iter) {
        Array.ForEach(items, i => {
            Console.Write("{0:D2} ", i);
        });
        Console.WriteLine();
    }
