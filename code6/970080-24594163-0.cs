	public class UserData
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Work { get; set; }
		public string Home { get; set; }
		public IEnumerable<PropertyInfo> GetVariance(UserData user)
		{
			foreach (PropertyInfo pi in user.GetType().GetProperties()) {
				object valueUser = typeof(UserData).GetProperty (pi.Name).GetValue (user);
				object valueThis = typeof(UserData).GetProperty (pi.Name).GetValue (this);
				if (valueUser != null && !valueUser.Equals(valueThis))
					yield return pi;
			}
		}
	}
