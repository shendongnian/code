    public class Error
    {
      public String name {  get; set; }
      public String description {  get; set; }
      public int number {  get; set; }
      public Error() // you must add a parameter-less constructor
      {
      }
      public Error(String name, String description)
      {
        this.name = name;
        this.description = description;
        // number = 0; // no need for this - the default is 0
      }
    }
