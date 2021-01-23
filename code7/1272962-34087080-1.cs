    double j = 9.88131291682493E-324;
    Console.WriteLine(j * 0.1 == 0);             // "False"
    double k = j * 0.1;
    Console.WriteLine(k == 0);                   // "True"
    Console.WriteLine((double)(j * 0.1) == 0);   // "True", double-to-double cast!
