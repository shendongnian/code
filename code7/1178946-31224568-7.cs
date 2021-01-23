    // declare variables
    var x = Expr.Symbol("x");
    var y = Expr.Symbol("y");
    
    // Parse left and right side of both equations
    Expr aleft = Infix.ParseOrThrow("(4-x)*2");
    Expr aright = Infix.ParseOrThrow("(y-1)*10+2");
    Expr bleft = Infix.ParseOrThrow("x");
    Expr bright = Infix.ParseOrThrow("y*2+1");
    // Solve both equations to x
    Expr ax = SolveSimpleRoot(x,aleft-aright); // "8 - 5*y"
    Expr bx = SolveSimpleRoot(x,bleft-bright); // "1 + 2*y"
    // Equate both terms of x, solve to y
    Expr cy = SolveSimpleRoot(y,ax-bx); // "1"
    // Substitute term of y into one of the terms of x
    Expr cx = Algebraic.Expand(Structure.Substitute(y,cy,ax)); // "3"
    // Print expression in Infix notation
    Console.WriteLine(Infix.Print(cx)); // x=3
    Console.WriteLine(Infix.Print(cy)); // y=1
