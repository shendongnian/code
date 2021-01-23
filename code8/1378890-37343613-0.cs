	class Account
	{
		public static FilterProperty[] Whitelist = {
			new FilterProperty(nameof(Account.ID), "accountId"),
			new FilterProperty(nameof(Account.Username), "accountName")
		};
		//...
	}
