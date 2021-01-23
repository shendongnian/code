	public class Account 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ContactId { get; set; }
		[InverseProperty("Contact")]
		public virtual ICollection<Contact> ContactsCollection { get; set; }
		
        /// <summary>
        /// Represents a list of all Contacts with an Active Status
        /// </summary>
		[NotMapped]
		public ICollection<Contact> Contacts
		{ 
			get 
			{
				return ContactsCollection.Where(c => c.Status == Status.Active).ToList();
			}
		}
	}
