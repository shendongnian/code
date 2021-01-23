    public class ContactInfo {
		public ContactInfo() {
			this.owners = new HashSet<Ownership>();
			this.emergencyContacts = new HashSet<Ownership>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
        // *** other members ellided ***	
		[InverseProperty("owner")]
		public virtual ICollection<Ownership> owners { get; private set; }
		[InverseProperty("emergencyContact")]
		public virtual ICollection<Ownership> emergencyContacts { get; private set; }
	}
