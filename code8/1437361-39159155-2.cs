    public class MyCoolClass
    {
       public IEnumerable<Feature> features {get; set;}
    }
    public class Feature 
    {
       public Attributes Attributes {get; set;}
       public Geometry Geometry {get; set;} 
    }
    public class Attributes 
    {
       public int ObjectId {get; set;}
       public string Schcd {get; set;}
       public string Schnm {get; set;}
    }
    public class Geometry
    {
       public double X {get; set;}
       public double Y {get; set;}
    }
