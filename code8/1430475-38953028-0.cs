    public interface listobject
    {
        string description();
    }
    class Fruit:listobject
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
    class Car : listobject
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
