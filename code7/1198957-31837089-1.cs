    User u = new User()
    {
        FirstName = "Home",
        LastName = "Simpson",
        Likes = new System.Collections.ObjectModel.Collection<Likes>()
        {
            new Likes() { Sport = "Bowling", Food = "Donut", Music = "Rock", Place = "Springfield" }
        }
    };
    
    string flattenedHomer = ConvertUserToFlattenedJson(u);
