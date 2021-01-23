    public class Phone
    {
       public class PropertiesModel
       {
          public string model;
          public string manufacturer;
       }
       
       public PropertiesModel Properties { get; }
       public Phone()
       {
          Properties = new PropertiesModel();
          Properties.model = "foo";
          Properties.manufacturer = "bar";
       }
    }
