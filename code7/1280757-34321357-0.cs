        public class ViewModel
        {    
                public Car SelectedCar{ get; set; }
                public IEnumerable<Car> Cars{ 
                    get  {
                        var cars = YOUR_DATA_STORE.Cars.ToList();
                        SelectedCar = cars.FirstOrDefault(car=>car.Model == "VW");
                        return cars;
                    }
                }
        }
        
        public class Car 
        {
            public string Model {get;set;}
        }
    
