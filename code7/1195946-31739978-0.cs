    public A() 
    {
        B b = new B();
        b.LoadData();
        this.Prop1 = b.Prop1;
        this.Prop2 = b.Prop2;
    }
