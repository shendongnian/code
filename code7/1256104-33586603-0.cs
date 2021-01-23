    namespace ClassLibrary1
    {
        public class Class1
        {
            public static void MyCheck()
            {
                WindowsIdentity identity = Thread.CurrentPrincipal == null
                    ? null
                    : Thread.CurrentPrincipal.Identity as WindowsIdentity;
    
                if (identity != null && identity.IsAuthenticated && !identity.IsAnonymous)
                {
                    var validated = new WindowsIdentity(identity.Token);
                    if (!validated.User.Equals(identity.User) || !validated.IsAuthenticated || validated.IsAnonymous)
                        throw new Exception("Something fishy is going on, don't trust it");
                    else
                        throw new Exception("Good! Use the validated one. name is:" + validated.Name);
                }
                else
                    throw new Exception("not in");
            }
        }
    }
