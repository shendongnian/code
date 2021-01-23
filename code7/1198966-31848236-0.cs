        class NestedUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Sport { get; set; }
            public string Music { get; set; }
            public string Food { get; set; }
            public string Place { get; set; }
            public void AddLikes(System.Collections.ObjectModel.Collection<Likes> likes)
            {
                foreach (Likes like in likes)
                {
                    Sport += like.Sport + ",";
                    Music += like.Music + ",";
                    Food += like.Food + ",";
                    Place += like.Place + ",";
                }
                
                if (Sport != string.Empty)
                {
                    Sport = Sport.Substring(0, Sport.Length - 1);
                }
                if (Music != string.Empty)
                {
                    Music = Music.Substring(0, Music.Length - 1);
                }
                if (Food != string.Empty)
                {
                    Food = Food.Substring(0, Food.Length - 1);
                }
                if (Place != string.Empty)
                {
                    Place = Place.Substring(0, Place.Length - 1);
                }
            }
        }
