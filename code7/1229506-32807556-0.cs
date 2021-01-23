        [HttpGet]
		public dynamic Get([FromQuery] string withUser)
		{
			if (string.IsNullOrEmpty(withUser))
			{
				return new string[] { "project1", "project2" };
			}
			else
			{
				return "hello " + withUser;
			}
		}
