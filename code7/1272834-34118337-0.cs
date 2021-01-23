        public class Organisation
        {
          public Guid Id { get; set; }
          public String Name { get; set; }
          public String Description { get; set; }
          //etc etc
    
          public Guid OrgTypeId { get; set; }
    
          #region Navigation properties
    
          public virtual OrgType OrgType { get; set; }
    
          #endregion
    
       }    
        
        public class OrgType 
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
            public string Description { get; set; } 
            #region Navigation properties
    
            public virtual ICollection<Organisation> Organisations { get; set; }              
            #endregion
       }
