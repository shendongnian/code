    public class ViewModel {
        public ObservableCollection<CarType> CarTypes { get; private set; }
        public ViewModel() {
            CarsTypes = new ObservableCollection<CarType>();
            var sportsCars = new CarType("Sports cars");
            sportscars.Cars.Add(new Car() { Make = "Ferrari", Model = "F430" });
            CarTypes.Add(sportsCars);
        }
    }
