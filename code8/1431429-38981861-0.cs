	static void Main(string[] args)
	{
		// Declare some references to work with (this data is rubbish, it's just here so
		// that everything compiles)
		var userManager = new UserManager<User, Key>(null);
		var user = new User();
		var claims = new List<Claim>();
		var claimTasks = new List<Task<IdentityResult>>();
		// This is basically the code that appears in the question - it compiles fine
		foreach (var claim in claims)
		{
			claimTasks.Add(userManager.AddClaimAsync(user.Id, claim));
		}
		var claimResultSucceeded = Task.WhenAll(claimTasks).IsCompleted;
    }
    // This struct and class have no purpose other than making the code compile
	public struct Key : IEquatable<Key>
	{
		public bool Equals(Key other) { throw new NotImplementedException(); }
	}
	public class User : IUser<Key>
	{
		public Key Id
		{
			get { throw new NotImplementedException(); }
		}
		public string UserName
		{
			get {  throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
	}
