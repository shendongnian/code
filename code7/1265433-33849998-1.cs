    private IEnumerable<string> GetNonConsecutiveEmails(List<string> list)
    {
    	var emailAddresses = list.Distinct().Select(email => new { Email = email, Domain = email.Split('@')[1]}).ToArray();
    	var groups = emailAddresses
    				.GroupBy(addr => addr.Domain)
    				.OrderByDescending(g => g.Count())
    				.Select (group => new { Domain = group.Key, EmailAddresses = new Stack<EmailAddress>(group)})
    				.ToArray()
    				.Dump();
    	
    	EmailAddress lastEmail = null;
    	while(groups.Any(g => g.EmailAddresses.Any()))
    	{
    		lastEmail = groups.First(g => g.EmailAddresses.Any() && (lastEmail == null ? true : lastEmail.Domain != g.Domain)).EmailAddresses.Pop();
    		yield return lastEmail.Email;
    	}
    }
    
    class EmailAddress
    {
    	public string Domain;
    	public string Email;
    }
