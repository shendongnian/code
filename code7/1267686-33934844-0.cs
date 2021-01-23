        private DateTime hour;
        [Required]
        public DateTime Hour  //this is my mapped property
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
                //update unmapped property 
                hourString = value.ToString("HH:mm");
            }
        }
        private string hourString;
        [NotMapped]
        public string HourString {
            get
            {
                return hourString;
            }
            set
            {
                hour = new DateTime(hour.Year, hour.Month, hour.Day, Convert.ToInt16(value.Substring(0, 2)), Convert.ToInt16(value.Substring(3, 2)), 0);
            }
        }
