    public class Manager
    {
       [JsonIgnore]
       public Employee[] Employees { get; set; }
       
       [JsonProperty("Employees")]
       public Employee[] SerializableEmployees
       {
           get { return Employees.Where(e => e.Name != "Bob").ToArray(); }
           set { Employees = value; }
       }
    }
