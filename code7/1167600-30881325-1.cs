    using OurCompany.Some.Location;
    namespace OurCompany
    {
        namespace This
        {
            namespace That
            {
                class BeepBoop
                {
                    private void DoSomething()
                    {
                        Foo.MethodName();  // No good; Foo is a namespace here.
                    }
                }
            }
        }
    }
