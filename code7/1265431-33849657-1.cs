	using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			var seed = new List<string>()
			{
				"1@a.com",
				"2@a.com",
				"3@a.com",
				"4@a.com",
				"5@a.com",
				"6@a.com",
				"7@a.com",
				"8@a.com",
				"9@a.com",
				"10@a.com",
				
				"1@b.com",
				"2@b.com",
				"3@b.com",
	
				"1@c.com",
				"4@b.com",
				"2@c.com",
				"3@c.com",
				"4@c.com"
			};
			
			var work = seed
                // Create a list of EmailAddress objects
				.Select(s => new EmailAddress(s)) // s.ToLowerCase() ?
                // Group the list by Domain
				.GroupBy(s => s.Domain)
                // Create a List<EmailAddressGroup>
				.Select(g => new EmailAddressGroup(g))
				.ToList();
			
			var currentDomain = string.Empty;
			while(work.Count > 0)
			{
                // this list should not be the same domain we just used
				var noDups = work.Where(w => w.Domain != currentDomain);
                // if none exist we are done, or it can't be solved
				if (noDups.Count() == 0)
				{
					break;
				}
                // find the first group with the most items
				var workGroup = noDups.First(w => w.Count() == noDups.Max(g => g.Count()));
                // get the email address and remove it from the group list
				var workItem = workGroup.Remove();
				
                // if the group is empty remove it from *work*
				if (workGroup.Count() == 0)
				{
					work.Remove(workGroup);
					Console.WriteLine("removed: " + workGroup.Domain);
				}
				
				Console.WriteLine(workItem.FullEmail);
				
                // last domain looked at.
				currentDomain = workItem.Domain;
			}
			
			Console.WriteLine("Cannot disperse email addresses affectively, left overs:");
			
			foreach(var workGroup in work)
			{
				while(workGroup.Count() > 0)
				{
					var item = workGroup.Remove();
					Console.WriteLine(item.FullEmail);
				}
			}
				
				
		}
		
		public class EmailAddress
		{
			public EmailAddress(string emailAddress)
			{
				// Additional Email Address Validation
				
				var result = emailAddress.Split(new char[] {'@'}, StringSplitOptions.RemoveEmptyEntries)
					.ToList();
				
				if (result.Count() != 2)
				{
					new ArgumentException("emailAddress");
				}
				
				this.FullEmail = emailAddress;
				this.Name = result[0];
				this.Domain = result[1];
			}
			
			public string Name { get; private set; }
			public string Domain { get; private set; }
			public string FullEmail { get; private set; }
		}
		
		public class EmailAddressGroup
		{
			private List<EmailAddress> _emails;
			
			public EmailAddressGroup(IEnumerable<EmailAddress> emails)
			{
				this._emails = emails.ToList();
				this.Domain = emails.First().Domain;
			}
			
			public int Count()
			{
				return _emails.Count();
			}
			
			public string Domain { get; private set; }
			
			public EmailAddress Remove()
			{
				var result = _emails.First();
				_emails.Remove(result);
				return result;
			}
		}
	}
