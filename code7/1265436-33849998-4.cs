    private IEnumerable<string> GetNonConsecutiveEmails(List<string> list)
    {
        var emailAddresses = list.Distinct().Select(email => new EmailAddress { Email = email, Domain = email.Split('@')[1]}).ToArray();
        var groups = emailAddresses
                    .GroupBy(addr => addr.Domain)
                    .Select (group => new { Domain = group.Key, EmailAddresses = new Stack<EmailAddress>(group)})
                    .ToList();
    
        EmailAddress lastEmail = null;
        while(groups.Any(g => g.EmailAddresses.Any()))
        {
    		// Try and pick from the largest stack.
            var stack = groups
    			.Where(g => (g.EmailAddresses.Any()) && (lastEmail == null ? true : lastEmail.Domain != g.Domain))
    			.MaxBy(g => g.EmailAddresses.Count);
    		
    		// Null check to account for only 1 stack being left.
            // If so, pop the elements off the remaining stack.   
    		lastEmail = (stack ?? groups.First(g => g.EmailAddresses.Any())).EmailAddresses.Pop();
            yield return lastEmail.Email;
        }
    }
    
    class EmailAddress
    {
        public string Domain;
        public string Email;
    }
    
    public static class Extensions
    {
    	public static T MaxBy<T,U>(this IEnumerable<T> data, Func<T,U> f) where U:IComparable
    	{
    		return data.Aggregate((i1, i2) => f(i1).CompareTo(f(i2))>0 ? i1 : i2);
    	}
    }
