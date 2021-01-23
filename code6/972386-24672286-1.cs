    var v1 = value1(); //seven byte returned. 
    var v2 = value2(); //next four byte returned.
    var join = new byte[v1.Length + v2.Length];
    // copy v1 at index 0 of join
    Array.Copy(v1, 0, join, 0, v1.Length); 
    // copy v2 at index v1.Length of join
    Array.Copy(v2, 0, join, v1.Length, v2.Length); 
