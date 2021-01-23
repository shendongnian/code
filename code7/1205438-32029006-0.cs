    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
    
        [Required]
        public string LastName { get; set; }
    
        [InverseProperty("CreatedBy")]
        public virtual ICollection<MaterialsList> CreatedMaterialsLists { get; set; }
        [InverseProperty("AssignedTo")]
        public virtual ICollection<MaterialsList> AssignedMaterialsLists { get; set; }
    }
