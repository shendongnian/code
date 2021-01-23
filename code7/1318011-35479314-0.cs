	IEnumerable<User> OrderByScore(IDictionary<string,object> firebaseList)
	{
		return from user in firebaseList.Values.Cast<IDictionary<string,object>>()
            let name  = (string) user["name"]
            let score = int.Parse(user["score"].ToString())
			orderby score
			select new User { Name = name, Score = score};
	}
	
	class User
	{
        public string Name  {get;set;}
		public int    Score {get;set;}
	}
