    public class BaseClass
    {
        public void Call()
        {
            if (this is DerivedClass<TypeX>)
            {
                CallX();
            }
            else if (this is DerivedClass<TypeY>)
            {
                CallY();
            }
            else
            {
                // Standard code
            }
        }
    }
