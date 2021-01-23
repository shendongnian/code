    namespace Assembly_1
    {
        //TIP:if it does not inherit class 'ConsoleApplication1.Base' then we can not access any thing beacuse this is different assembly.
        //TIP:only INTERNAL is NOT accessible , rest all are accessible from first assembly if it inherits class 'Soul'
        public class Derived : ConsoleApplication1.Base
        {
            public class PublicDerived
            {
                public static void fn_PublicDerived()
                {
                    PublicBase.fn_PublicBase();             //YES, becuase this is 'public'
                  //PrivateBase.fn_PrivateBase();           //No, becuase this is 'private'
                    ProtectedBase.fn_ProtectedBase();       //YES, becuase this is 'protected'
                  //InternalBase.fn_InternalBase();         //No, becuase this is 'internal'
                    ProInternalBase.fn_ProInternalBase();   //YES, becuase this is 'protected internal'
                }
            }
        }
    }
