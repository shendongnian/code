      private DateTime dateTimeUpdated = default(DateTime);
        public DateTime DateTimeUpdated
        {
           get
           {
              return (this.dateTimeUpdated== default(DateTime))
                 ? this.dateTimeUpdated= DateTime.Now
                 : this.dateTimeUpdated;
           }
        
           set { this.dateTimeUpdated= value; }
        }
