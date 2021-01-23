    public interface arrayobject 
    {
        string description();
    }
    class Fruit:arrayobject
    {
        public string fruittype;
        public Fruit(string type)
        {
            fruittype = type;
        }
        public string description()
        {
            return fruittype;
        }
    }
    class Car : arrayobject
    {
        public string Cartype;
        public Car(string type)
        {
            Cartype = type;
        }
        public string description()
        {
            return Cartype;
        }
    }
