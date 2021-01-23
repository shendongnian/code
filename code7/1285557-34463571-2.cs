	public IHttpActionResult ImportUsers([FromBody] IEnumerable<User> newUsers)
	{
		var sb = new StringBuilder();
		foreach (var user in newUsers)
		{
			sb.Append(user.Id);
			sb.Append("/");
			sb.Append(user.Name);
			sb.Append("/");
			for (int i = 0; i < user.Skills.Length; i++)
			{
				sb.Append(user.Skills[i].SN);
				sb.Append("-");
				sb.Append(user.Skills[i].SL);
				if (i != user.Skills.Length)
					sb.Append(",");
			}
			sb.Append(";");
		}
		var result = sb.ToString();
		return Ok(result);
	}
