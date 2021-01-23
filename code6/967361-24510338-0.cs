    public class Person
    {
        private readonly CarCollection cars;
        public Person() {
            cars = new CarCollection(this);
        }
        [XmlElement]
        public CarCollection Cars { get { return cars; } } 
    
        ...
    }
