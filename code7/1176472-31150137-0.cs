    class A
    {
        string strA = "A";
        public override string ToString() { return strA; }
        //Added a example of somthing not declared in Object
        public virtual string Example() { return "I am in A!"; }
    }
    class B : A
    {
        string strB = "B";
        public override string ToString() { return base.ToString() + strB; }
        //Notice the override instead of the virtual.
        public override string Example() { return "I am in B!"; }
    }
    class C : B
    {
        string strC = "C";
        public override string ToString() { return base.ToString() + strC; }
        public override string Example() { return "I am in C!"; }
    }
