    public class DC_Reservation() : INotifyPropertyChanged {
    
        protected Reservation _PersonReservation ;
        public Reservation PersonReservation {
            get { return _PersonReservation ; }
            set {
                _PersonReservation = value;
                NotifyPropertyChanged("PersonReservation ");
            }
        }
        protected Room _PersonRoom ;
        public Room PersonRoom {
            get { return _PersonRoom ; }
            set {
                _PersonRoom = value;
                NotifyPropertyChanged("PersonRoom");
            }
        }
        protected Person _myPerson ;
        public Person myPerson {
            get { return _myPerson ; }
            set {
                _myPerson = value;
                NotifyPropertyChanged("myPerson ");
            }
        }
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged( string PropertyName ) {
			if ( PropertyChanged != null ) {
				PropertyChanged( this, new PropertyChangedEventArgs( PropertyName ) );
			}
		}
   
    }
