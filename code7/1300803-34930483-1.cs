    private interface IBase
    {
        void M();
    }
    class C : IDerived1, IDerived2
    {
        //Which method should now be called when using IBase.M?
        void IDerived1.M() {} 
        void IDerived2.M() {}  
    }
