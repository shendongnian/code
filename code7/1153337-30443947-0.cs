    Triangle a(3, 4, 5);
    Triangle b(30, 40, 50);
    // let's adjust triangle a to match b
    try {
        a.Side1 = b.Side1;  // nope
        a.Side2 = b.Side2;
        a.Side3 = b.Side3;
    }
    catch(IllegalTriangleException e) {
        // darn, we accidentally went through an invalid state of (30, 4, 5)
    }
