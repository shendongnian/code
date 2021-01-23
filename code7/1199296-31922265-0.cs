    internal sealed class EFPlace : Place
    {
        DbGeography EFLocation 
        {
            get
            {
                return DbGeography.FromText(string.Format("POINT({0} {1})", Location.Longitude, Location.Latitude);
            }
            set
            {
                //vice versa convertion, I don't know, how to do it :)
            }
        }
    }
