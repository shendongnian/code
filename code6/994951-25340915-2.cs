    List<double[]> myList = new List<double[]>();
    double[] a = new double[3];
    
    a[0] = 1;
    a[1] = 2;
    a[2] = 3;
    myList.Add(a); // Ok List[0] = 1 2 3
    
    a = new double[3];
    a[0] = 4;      // List[0] = 4 2 3
    a[1] = 5;      // List[0] = 4 5 3
    a[2] = 6;      // List[0] = 4 5 6
    myList.Add(a); // List[0] = 1 2 3 and List[1] = 4 5 6
