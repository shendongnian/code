    public IHttpActionResult ImportUsers([FromBody] IEnumerable<User> newUsers)
	{
		var agents = string.Join(";", newUsers.Select(GetFormattedUserString));
		return Ok(agents);
	}
	private string GetFormattedUserString(User user)
	{
		return string.Concat(user.Id, "/", user.Name, "/", string.Join(",", user.Skills.Select(skill => string.Concat(skill.SN, "-", skill.SL))));
	}
