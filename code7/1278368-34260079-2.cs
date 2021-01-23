     public class Movie
            {
                public string movieName { get; set; }
                public string onDVD { get; set; }
                public string onBluRay { get; set; }
                public string genreType { get; set; }
                public string directorName { get; set; }
                public string producerName { get; set; }
                public int movieLength { get; set; }
                public string moveRating { get; set; }
                private DateTime _ReleaseDate;
                private double _AgeInDays;
                public DateTime ReleaseDate
                {
                    get { return _ReleaseDate; }
                    set
                    {
                        _ReleaseDate = value;
                        _AgeInDays = (DateTime.Now - value).TotalDays;
                    }
                }
                public double AgeInDays
                {
                    get { return _AgeInDays; }
                }
            }
        
