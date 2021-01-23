    class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car car1, Car car2) {
            return car1.Manufacturer.Equals(car2.Manufacturer)
                && car1.ModelName.Equals(car2.ModelName);
        }
        public int GetHashCode(Car car) {
            return car.Manufacturer.GetHashCode() * 31 + car.ModelName.GetHashCode();
        }
    }
