	public class ConsoleUser : .... // some base IDomainEntity inheritence
	{
		#region Account
		//account information
		public virtual String UserName { get; set; }
		public virtual String Password { get; set; }
		public virtual DateTime? LastLogin { get; set; }
		#endregion
	}
