    Test1<int> x = new Test1<int>();
    x.Test1Method(1); //valid
    x.Test1Method(2); //valid
    x.Test1Method("str"); //invalid
    Test2 x1 = new Test2();
    x1.Test2Method(1); //valid
    x1.Test2Method("str"); //valid
