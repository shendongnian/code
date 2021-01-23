    public class Movie
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                //Notify property changed stuff (if required)
                //This is obviously a stupid example, but the idea
                //is to contain model related logic inside the model.
                //It makes more sense inside the model.
                MyFavourite = value == "My Movie";
            }
        }
        private bool _MyFavourite;
        public bool MyFavourite
        {
            get { return _MyFavourite; }
            set
            {
                _MyFavourite = value;
                //Notify property changed stuff.
            }
        }
    }
