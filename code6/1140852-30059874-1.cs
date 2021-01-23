    var setOne = new HashSet<int> { 1, 3 };
    
    var setTwo = new HashSet<int> { 1, 2, 3 };
    
    Console.WriteLine(setOne.IsSubsetOf(setTwo)); // True
    Console.WriteLine(setTwo.IsSubsetOf(setOne)); // False
