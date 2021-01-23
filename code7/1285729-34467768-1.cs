    var r1 = new Ratio(1, 10); // 1/10
    var r2 = new Ratio(2, 20); // 2/20
    Console.WriteLine(r1 >= r2); // true
    Console.WriteLine(r1 > r2);  // false
    Console.WriteLine(r1 < r2);  // false
    Console.WriteLine(r1 == r2); // true
---
    var r1 = new Ratio(1, 10); // 1/10
    var r2 = new Ratio(1, 11); // 1/11
    Console.WriteLine(r1 >= r2); // true
