    public class MyObject {
      public List <Feature> Features {get;set;} 
    }
    
    public class Feature {
      public MyAttributes Attributes {get;set; }
      public Geometries Geometries {get;set; }
    }
    public class MyAttributes {
      public int ObjectID {get;set;}
      public string Schcd {get;set;}
      public string Schnm {get;set;}
    }
    
    public class Geometries {
      public double X {get;set;}
      public double Y {get;set;}
    }
