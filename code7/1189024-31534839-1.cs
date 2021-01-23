    var list = new[]{ 1, 1, 2, 5, 8, 1, 9, 1, 2 };
    Console.WriteLine(list.Contains(new[]{2,5,8,1,9})); // True
    Console.WriteLine(list.Contains(new[]{1,2,5,8,1})); // True
    Console.WriteLine(list.Contains(new[]{5,2,1}));     // False
    Console.WriteLine(list.Contains(new[]{1,2,5,1,8})); // False
    Console.WriteLine(list.Contains(new[]{1,1,2}));     // True
    Console.WriteLine(list.Contains(new[]{1,1,1,2}));   // False
