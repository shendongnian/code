    namespace OurCompany
    {
        namespace This
        {
            namespace That
            {
                using OurCompany.Some.Location;
                class BeepBoop
                {
                    private void DoSomething()
                    {
                        Foo.MethodName();  // Puh-wha?  This works?
                    }
                }
            }
        }
    }
