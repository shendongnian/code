    interface ICloneableExtended<T> {
        Clone();
    }
    
    class Car : ICloneableExtended<Car> {
        public Car Clone() {
            throw new NotImplementedException();
        }
    }
