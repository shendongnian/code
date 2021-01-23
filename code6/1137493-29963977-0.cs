        class A
        {
            public virtual void GetBonus(int value)
            {
                //if you define this method as seald no one can override this
            }
        }
    
        class B:A
        {
            public override void GetBonus(int value)
            {
                
            }
        }
    
        class C:B
        {
            public override void GetBonus(int value)
            {
                //here we override implementation of class B
            }
        }
    }
