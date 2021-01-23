        public MyViewModel( )
        {
            Cars = TheCarsDataLayerService.GetCars( );
        }
        private IObservable<Car> _cars;
        public IObservable<Car> Cars
        {
            get { return _cars; }
            set
            {
                if( _cars == value )
                    return;
                _cars = value;
                RasisePropertyChanged("Cars");
            }
        }
