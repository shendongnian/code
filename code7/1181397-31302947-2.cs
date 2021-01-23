    public class StatusIdentifer
    {
      [DefaultValue("1")]
      [Key]
      public int id {get; set}; //set can be removed here?
      public bool status {get:set;} //your boolean value
    }
