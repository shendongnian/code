		public IEnumerable<string> Contacts
		{
			get
			{
				return ContactCollection.Cast<ContactElement>().Select(x => x.Address); 	
			}
		}
		[ConfigurationProperty("contacts", IsDefaultCollection = false)]
		public ContactCollection ContactCollection
		{
			get { return ((ContactCollection)base["contacts"]); }
		}
