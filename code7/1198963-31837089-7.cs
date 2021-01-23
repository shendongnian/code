	static void Main(string[] args)
	{
	    var user1 = new User() { FirstName = "Homer", LastName = "Simpson" };
	    user1.AddSingleDetail("Sport", "Bowling");
	    user1.AddSingleDetail("Sport", "Sleeping");
	    user1.AddSingleDetail("Food", "Donut");
	    user1.AddSingleDetail("Music", "Rock");
	    string flattenedHomer1 = ConvertUserToFlattenedJson(user1);
	    var user2 = new User() { FirstName = "Homer", LastName = "Simpson" };
	    var likes1 = new Likes() { Food = "Donut", Music = "Rock", Place = "Springfield", Sport = "Bowling" };
	    var likes2 = new Likes() { Food = "Steaks", Music = "Metal", Place = "Evergreen Terrace", Sport = "Sleeping" };
	    var proStuff = new ProfessionalStuff() { Title = "Boss" };
	    user2.AddDetails(likes1);
	    user2.AddDetails(likes2);
	    user2.AddDetails(proStuff);
	    string flattenedHomer2 = ConvertUserToFlattenedJson(user2);
	}
