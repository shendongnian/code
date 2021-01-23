    namespace TestWebApi.Controllers
    {
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        public void Post(ComplexClass data)
        {
            var xx = data.business_name;
            var y = xx + data.date_of_incorporation;
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
    public class ComplexClass
    {
        public string business_name { get; set; }
        public string fk_loan_id { get; set; }
        public proprietor_details proprietor_details {get;set;}
        public string date_of_incorporation { get; set; }
        public financial_details financial_details { get; set; }
        public residence_address residence_address {get;set;}
        public personal_details personal_details {get;set;}
    }
    public  class financial_details
    {
      public string TAN { get; set; }
      public string TIN { get; set; }
      public string VAT { get; set; }
      public string  PAN { get; set; }
      }
