    // 1
    array1.Intersect(array2).Any();
    // 2
    array1.Except(array2).Count() == array1.Distinct().Count();
    // 3.1
    array1.Any(array2.Contains);
    // 3.2
    array1.All(x => !array2.Contains(x)); 
