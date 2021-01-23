    var a = new A();
    DoSomething(a.One);
    public void DoSomething(B instance) 
    {
        //What should the result be here?
        //Should be 'CustomStuff:Something', right?    
    }
    var a = new A();
    a.Two = a.One
    DoSomething(a.One);
    //Now what should it be?
    var a = new A();
    a.Two = a.One
    var tmp = a.One;
    a.One = a.Two = null;
    DoSomething(tmp);
 
    //And now?
