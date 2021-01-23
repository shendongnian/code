    public class Car
    {
         public int Wheels { get; set; }
    }
    public class Bike
    {
        public int Pedals { get; set; }
    }
    public class ListManager
    {
        //Defina all list properties here:
        public List<Car> Car { get; } = new List<Car>();
        public List<Bike> Bikes { get; } = new List<Bike>();
        //Gets a list instance by its element type
        public object GetList(Type ElemType)
        {
            //Get the first property that is of the generic type List<> and that it's first generic argument equals ElemType,
            //then, obtain the value for that property
            return GetType().GetProperties()
                .Where(x =>
               x.PropertyType.IsGenericType &&
               x.PropertyType.GetGenericTypeDefinition() == typeof(List<>) &&
               x.PropertyType.GetGenericArguments()[0] == ElemType).FirstOrDefault().GetValue(this);
        }
        public void Add(object Value)
        {
            var ElemType = Value.GetType();
            var List = GetList(ElemType);
            //If list had more Add method overloads you should get all of them and filter by some other criteria
            var AddMethod = List.GetType().GetMethod("Add");
            //Invoke the Add method for the List instance with the first parameter as Value
            AddMethod.Invoke(List,new [] { Value });
        }
    }
