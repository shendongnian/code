    public partial class EFEntity: DbContext
            {
                public EFEntity()
                    : base("name=EFEntity")
                {
                    Configuration.ProxyCreationEnabled = false;
                }
                ......
            }
