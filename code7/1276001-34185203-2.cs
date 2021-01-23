    namespace Assembly1
    {
        public class BaseClass
        {
            public int PublicMember;
            protected internal int ProtectedInternalMember;
            internal int InternalMember;
            protected int ProtectedMember;
            private int PrivateMember;
            
            public class PublicClass { }
            protected internal class ProtectedInternalClass { }
            internal class InternalClass { }
            protected class ProtectedClass { }
            private class PrivateClass { }
        }
    
        public class InternalClass
        {
            public InternalClass()
            {
                BaseClass class0Instance = new BaseClass();
                var publicMember = class0Instance.PublicMember;
                var protectedInternalMember = class0Instance.ProtectedInternalMember;
                var internalMember = class0Instance.InternalMember;
                var protectedMember = "not accessible";
                var privateMember = "not accessible";
    
                var publicClass = new BaseClass.PublicClass();
                var protectedInternalClass = new BaseClass.ProtectedInternalClass();
                var internalClass = new BaseClass.InternalClass();
                var protectedClass = "not accessible";
                var privateClass = "not accessible";
            }
        }
    
        public class InternalInheritedClass : BaseClass
        {
            public InternalInheritedClass()
            {
                var publicMember = this.PublicMember;
                var protectedInternalMember = this.ProtectedInternalMember;
                var internalMember = this.InternalMember;
                var protectedMember = this.ProtectedMember;
                var privateMember = "not accessible";
    
                var publicClass = new BaseClass.PublicClass();
                var protectedInternalClass = new BaseClass.ProtectedInternalClass();
                var internalClass = new BaseClass.InternalClass();
                var protectedClass = new BaseClass.ProtectedClass();
                var privateClass = "not accessible";
            }
        }
    }
