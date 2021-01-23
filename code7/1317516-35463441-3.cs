    interface I
    {
        void PutMammal (Mammal mammal);
    }
    class C : I
    {
        public PutMammal(Animal animal) { ... } // not legal.
    }
