	static async void Main(string[] args)
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
        // WhenAll returns a single task that will be completed when all of the individual
        // claims tasks have completed
		var claimResults = await Task.WhenAll(claimTasks);
        // When this happens, you should be able to look at each of the IdentityResults
        // instances in the claimResults array to ensure they all succeeded
        // Note: I'm presuming a little here since I'm not too familiar with these types, but
        // it seems reasonable that the Succeeded flag on each IdentityResult should indicate
        // whether or not it was successfully retrieved
        var allRequestsSucceeded = claimResults.All(c => c.Succeeded);
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
