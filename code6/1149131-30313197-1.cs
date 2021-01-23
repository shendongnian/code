    public class Car
    {
        public List<Part> listOfParts = new List<Part>();
    }
    public class Part
    {
        // ..
    }
    public class CustomPart extends Part
    {
        // ..
    }
    // 
    Car car = new Car();
    car.listOfParts(new Part());
    car.listOfParts(new CustomPart());
