    Class MainModel{
        List<ICar> cars;
        ICar selectedCar;
    
        ShowData(IEnumerable<ICar> cars){
            foreach (var car in cars)
                {
                    _car.Add(car);
                }
            this.selectedCar = this.cars.FirstOrDefault();
        } 
    
         private ObservableCollection<Car> _cars=new ObservableCollection<Car>();
    
            public ObservableCollection<Car> Cars
            {
                get { return _cars; }
                set { _cars= value; }
            }
        public object Car{
            get{ return this.selectedCar.Content;}
        }
    }
