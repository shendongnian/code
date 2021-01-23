    class YourViewModel {
        private bool allowPickDate;
        public bool AllowPickDate {
            get {
                return this.allowPickDate;
            }
            set {
                if (this.allowPickDate != value) {
                    this.allowPickDate = value;
                    this.OnPropertyChanged("AllowPickDate");
                }
           }
       }
       public UrgentType Urgent {
           get {
               ....
           }
           set {
               ....
               if (value == [whatever you expect]) {
                   this.AllowPickDate = true;
               }
               else {
                   this.AllowPickDate = false;
               }
           }
      }
