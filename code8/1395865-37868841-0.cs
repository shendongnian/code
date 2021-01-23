    public class Location : DomainBase
    {
        private int _placeId;
        private string _description;
    
        public int PlaceId
        {
            get { return _placeId; }
            set
            {
                if (_placeId == value) return;
                _placeId = value;
                OnPropertyChanged();
            }
        }
    
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();  // make sure  this Notify RepPlusDescription
            }
        }
    
        public string RepPlusDescription
        {
            get 
            {   
                string result;
                Place place = Repository.Places.FirstOrDefault(o => o.Id == placeId);
                if (place != null)
                {
                    string placeName = place.Name;
                    if (!String.IsNullOrWhiteSpace(placeName))
                    {
                        result = placeName + ", ";
                    }
                }
                return result += location.Description; 
            }
         }
    }
