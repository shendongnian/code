    using Assembly1;
    namespace Assembly2
    {
        public class ExternalClass
        {
            public ExternalClass()
            {
                BaseClass class0Instance = new BaseClass();
                var publicMember = class0Instance.PublicMember;
                var protectedInternalMember = "not accessible";
                var internalMember = "not accessible";
                var protectedMember = "not accessible";
                var privateMember = "not accessible";
    
                var publicClass = new BaseClass.PublicClass();
                var protectedInternalClass = "not accessible";
                var internalClass = "not accessible";
                var protectedClass = "not accessible";
                var privateClass = "not accessible";
            }
        }
    
        public class ExternalInheritedClass : BaseClass
        {
            public ExternalInheritedClass()
            {
                var publicMember = this.PublicMember;
                var protectedInternalMember = this.ProtectedInternalMember;
                var internalMember = "not accessible";
                var protectedMember = this.ProtectedMember;
                var privateMember = "not accessible";
    
                var publicClass = new BaseClass.PublicClass();
                var protectedInternalClass = new BaseClass.ProtectedInternalClass();
                var internalClass = "not accessible";
                var protectedClass = new BaseClass.ProtectedClass();
                var privateClass = "not accessible";
            }
        }
    }
