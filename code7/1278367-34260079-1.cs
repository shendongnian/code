        private DateTime  _ReleaseDate;
        private double _AgeInDays;
        public DateTime  ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value;
            _AgeInDays = (DateTime.Now - value).TotalDays; 
            }
        }     
        //here we define a read-only property this will gives you the age in days
        //when ever you assign value to the  ReleaseDate.
        //You cannot directly assign value to AgeInDays. 
        public double AgeInDays
        {
            get { return _AgeInDays; }            
        }
