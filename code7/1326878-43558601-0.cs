    namespace ConsoleApplication1
    {
        //A normal public class which contains all different types of access-modifier classes in the assembly named 'ConsoleApplication1'
        public class Base
        {
            public class PublicBase
            {
                public static void fn_PublicBase()
                {
                    Console.WriteLine("fn_PublicBase");
                }
            }
            private class PrivateBase
            {
                public static void fn_PrivateBase()
                {
                    Console.WriteLine("fn_PrivateBase");
                }
            }
            protected class ProtectedBase
            {
                public static void fn_ProtectedBase()
                {
                    Console.WriteLine("fn_ProtectedBase");
                }
            }
            internal class InternalBase
            {
                public static void fn_InternalBase()
                {
                    Console.WriteLine("fn_InternalBase");
                }
            }
            protected internal class ProInternalBase
            {
                public static void fn_ProInternalBase()
                {
                    Console.WriteLine("fn_ProInternalBase");
                }
            }       
            //TIP 1:This class is inside the same class 'Base' so everything is accessible from above.Hurray!!
            class Base_Inside
            {
                public static void fn_Base_Inside()
                {
                    //All methods are easily accessible.Does not consider a modified indeed.
                    PublicBase.fn_PublicBase();
                    PrivateBase.fn_PrivateBase();
                    ProtectedBase.fn_ProtectedBase();
                    InternalBase.fn_InternalBase();
                    ProInternalBase.fn_ProInternalBase();
                }
            }
        }
        //Different class but inside the same assembly named 'ConsoleApplication1'
        public class Base_Sibling  : Base
        {        
            //TIP 2:This class is NOT in same class 'Base' but in the same assembly so  only protected is NOT accessible rest all are accessible.        
            public void fn_Base_Sibling()
            {
                PublicBase.fn_PublicBase();
                //PrivateBase.fn_PrivateBase();     //ERROR:Accesibility of 'protected'            
                ProtectedBase.fn_ProtectedBase();   //protected is accessible because Base_Sibling inherit class 'Base'. you can not access it via Base.ProtectedBase
                InternalBase.fn_InternalBase();
                ProInternalBase.fn_ProInternalBase();
            }
        }
    }
