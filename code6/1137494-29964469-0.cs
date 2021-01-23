    class A
    {
        public virtual void GetBonus(int value) { }
    }
    class B : A
    {
        public sealed override void GetBonus(int value) { } // We seal this method
    }
    class C : B
    {
        public override void GetBonus(int value) // This line is invalid
          // because it cannot override the sealed member from class B.        
        {   }
    }
