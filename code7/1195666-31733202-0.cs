    public class PostEmployeeModel
    {
        public string Name {get; set;}
        public string Works {get; set;} 
    }
    [HttpPost]
    public ActionResult SetWorkStatus(PostEmployeeModel employee)
    {
        Work work = JsonConvert.DeserializeObject<Work>(employee.Works)
        // ...
    }
