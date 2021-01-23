    static class UserManager
    {
    	private static readonly Dictionary<string, User> ActiveUsers = new Dictionary<string, User>();
    	public static User GetInformation(string userId)
    	{
    		lock (ActiveUsers)
    		{
    			User user;
    			if (!ActiveUsers.TryGetValue(userId, out user))
    				ActiveUsers.Add(userId, user = new User(userId));
    			return user;
    		}
    	}
    	public static void RemoveUserAndSessions(string userId)
    	{
    		lock (ActiveUsers)
    		{
    			User user;
    			if (ActiveUsers.TryGetValue(userId, out user))
    			{
    				ActiveUsers.Remove(userId);
    				user.EndAllSessions();
    			}
    		}
    	}
    	public static void StartSession(string firstUserId, string secondUserId)
    	{
    		lock (ActiveUsers)
    		{
    			var firstUser = GetInformation(firstUserId);
    			var secondUser = GetInformation(secondUserId);
    			firstUser.StartSession(secondUser);
    			secondUser.StartSession(firstUser);
    		}
    	}
    }
    class User
    {
    	private Dictionary<string, User> sessions = new Dictionary<string, User>();
    	public string Id { get; private set; }
    	public User(string id) { Id = id; }
    	public void StartSession(User other)
    	{
    		sessions.Add(other.Id, other);
    	}
    	public void EndSession(User other)
    	{
    		sessions.Remove(other.Id);
    	}
    	public void EndAllSessions()
    	{
    		foreach (var other in sessions.Values)
    			other.EndSession(this);
    		sessions.Clear();
    	}
    }
