    int a = 1;
    int b = 1;
    int c;
    
    //task A
    c = a;   // c is now 1
    c = a++; // a is 1 at assignment so c is 1
             // after assignment, a becomes 2; this does not impact c
    
    //task B
    c = b;   // c is now 1
    c = b++; // b is 1 at assignment so c is 1
             // after assignment, b becomes 2; this does not impact c
    c = b;   // c is now 2
