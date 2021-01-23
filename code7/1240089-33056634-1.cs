	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
						
	public class Program
	{
		public static void Main()
		{
			string json2 = @"[{
		 'Email': 'james@example.com',
		  'Active': true,
		  'CreatedDate': '2013-01-20T00:00:00Z',
		  'Roles': [
			'User',
			'Admin']
		},
		{
		 'Email': 'james@example.com2',
		  'Active': true,
		  'CreatedDate': '2013-01-20T00:00:00Z',
		  'Roles': [
			'Userz',
			'Adminz'
		  ]
		}]";
		List<Account> account = new List<Account>();
		account.AddRange(JsonConvert.DeserializeObject<List<Account>>(json2));
		// james@example.com
		Console.Write(account[0].Email);
		}
	}
	public class Account
	{
		public string Email { get; set; }
		public bool Active { get; set; }
		public DateTime CreatedDate { get; set; }
		public IList<string> Roles { get; set; }
	}
 
