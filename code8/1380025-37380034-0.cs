    var a = new[] { 1, 2, };
    var b = new[] { 1, 2, };
    var c = new[] { 3, 4, };
    
    CollectionAssert.AreEqual(a, b); //passed
    CollectionAssert.AreEqual(b, c); //fails
