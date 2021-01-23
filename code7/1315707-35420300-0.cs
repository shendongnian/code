        public class IdentityUserClaim
        {
            public virtual string Name { get; set; }
        }
    
        public class Userclaim : IdentityUserClaim
        {
            public virtual int Id { get; set; }
    
            public virtual DateTime DateCreated { get; set; }
    
            public virtual DateTime DateUpdated { get; set; }
    
            public virtual string ClaimType { get; set; }
    
            public virtual string ClaimValue { get; set; }
        }
    
        public partial class UserclaimMap : ClassMap<Userclaim>
        {
            public UserclaimMap()
            {
                Table("UserClaim");
                Id(x => x.Id).Column("Id");
                Map(x => x.DateCreated).Column("DateCreated").Not.Nullable();
                Map(x => x.DateUpdated).Column("DateUpdated").Not.Nullable();
                Map(x => x.ClaimType).Column("ClaimType").Not.Nullable();
                Map(x => x.ClaimValue).Column("ClaimValue");
            }
        }
