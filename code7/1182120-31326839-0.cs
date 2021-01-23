    public class Car
    {
        public int Id { get; set; }
        public Car() { }
        public Car(int id) { Id = id; }
    }
    public class CarCollection
    {
        public List<Car> Cars { get; set; }
        public void AddCar(Car car) { Cars.Add(car); }
        
        public Car GetById(int id) { return Cars.Single(x => x.Id == id); }
        public CarCollection(List<Car> cars) { Cars = cars; }
        public CarCollection(Car car) { Cars = new List<Car>() { car }; }
    }
