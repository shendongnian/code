        public class User{
          
          [Key]
          public Guid UserId {get;set;}
    
          public virtual ICollection<UserRoleAssociation> UserRoleAssociations {get;set;}      
        }
        
        public class Role{
          [Key]
          public Guid RoleId {get;set;}
    
          public virtual ICollection<UserRoleAssociation> UserRoleAssociations {get;set;}
        }
        
        public class Association{
          [Key]
          public Guid AssociationId {get;set;}
    
          public virtual ICollection<UserRoleAssociation> UserRoleAssociations {get;set;}
        }
    
        public class UserRoleAssociation{
    
         [Key,ForeignKey("User"),Column(Order=1)]
         public Guid UserId {get;set;}
    
         [Key,ForeignKey("Role"),Column(Order=2)]
         public Guid RoleId {get;set;}
    
         [Key,ForeignKey("Associoation"),Column(Order=3)]
         public Guid AssociationId {get;set;}
    
         //Navigation Properties
    
         public virtual User User {get;set;}
         public virtual Role Role {get;set;}
         public virtual Association Association {get;set;}
    
    }
