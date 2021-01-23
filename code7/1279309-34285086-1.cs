    public void Foo(out int getme)
    { 
       getme = 1;   
    }
    
    public void FooGetter()
    { 
       int getme;
       Foo(out getme); 
       // at this point getme will contain value assigned in Foo
    }
