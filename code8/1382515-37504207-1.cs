        public virtual ICollection<Area> Areas { get; set; }
    ... and that you should populate the areas in the seeded entities:
        var cities = new City[]
        {
            new City { ProvinceId = 1, CityArabicName = "الرياض", CityEnglishName = "Riyadh",
                       Areas = areas1 },
            new City { ProvinceId = 2, CityArabicName = "جدة",  CityEnglishName = "Jeddah",
                       Areas = areas2 },
            new City { ProvinceId = 3, CityArabicName = "الدمام", CityEnglishName = "Dammam"},
            new City { ProvinceId = 4, CityArabicName = "بريدة", CityEnglishName = "Buraidah"}
        };
    ... where `areas1` and `areas2` obviously are the two collections of areas belonging to the first two cities. Now you're going to `AddOrUpdate` the cities only, because if a city must be added, its areas must be added too.
