    public class ListOfCars<T> : List<T> where T : Car { }
    
    public abstract class Car { }
    public class Porsche : Car { }
    public class Bmw : Car { }
