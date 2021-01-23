    public class Employee
    {
       [JsonProperty(PropertyName = "employee_name")]
       public string Name { get; set; }
    }
    private IRestResponse<Employee> GetEmployee()
    {
       var request = new RestRequest();
       request.Resource = "/api/employees"
       request.Method = Method.GET;
       var response = Execute<Employee>(request);
    }
    public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
    {
       // Pass in reusable ISerializer (can internally use Newtonsoft)
       request.JsonSerializer = new JsonNetSerializer(); 
       return client.Execute<T>(request); // Client is of type RestClient
    }
