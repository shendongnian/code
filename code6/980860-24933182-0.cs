    public class Place
    {
        public string EnglishName { get; set; }
        public string LocalizedName { get; set; }
    	public string Slug { get; set; }
    }
    void Main()
    {
      var places = new List<Place>
      {
        new Place { LocalizedName = "Localized1", EnglishName = "English1", Slug = "Slug" },	
    	new Place { LocalizedName = null, EnglishName = "English2", Slug = "Slug" },
    	new Place { LocalizedName = "Localized3", EnglishName = "English3", Slug = "Slug" },	
    	new Place { LocalizedName = null, EnglishName = "English4", Slug = "Slug" },
      };
      var slug = "Slug";
      var names = 
          from place in  places
          where place .Slug == slug
          select new { Name = !string.IsNullOrEmpty(place.LocalizedName ) 
                              ? place.LocalizedName 
                              : place.EnglishName };
      foreach (var name in names)
        Console.WriteLine(name);
    }
    // Displays:
    // Localized1
    // English2
    // Localized3
    // English4
