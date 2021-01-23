    public class Base { }
    public class DerivedA : Base { }
    public class DerivedB : Base { }
    List<Base> instances = new List<Base>();
    instances.Add(new DerivedA());
    instances.Add(new DerivedB());
     var results = instances.OfType<DerivedA>().FirstOrDefault();
