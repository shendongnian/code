     class Cars : IEnumerable<Car>
    {
        Car[] cars;
        public Cars(Car[] cars)
        {
            this.cars = cars;
        }
        public IEnumerator<Car> GetEnumerator()
        {
            for (int index = 0; index < cars.Length; index++)
                yield return cars[index];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
