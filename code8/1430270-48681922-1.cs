    [FunctionName("StackOverflowReturnJson")]
        public static HttpResponseMessage Run([HttpTrigger("get", "post", Route = "StackOverflowReturnJson")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info($"Running Function");
            try
            {
                log.Info($"Function ran");
                var myJSON = GetJson();  // Note: this actually returns an instance of 'Person' 
                // I want myJSON to look like:
                // {
                //   firstName:'John',
                //   lastName: 'Doe',
                //   orders: [
                //     { id:1, description:'...' },
                //     ...
                //   ]
                // }
                var response = req.CreateResponse(HttpStatusCode.OK, myJSON, JsonMediaTypeFormatter.DefaultMediaType); // DefaultMediaType = "application/json" does the 'trick'
                return response;
            }
            catch (Exception ex)
            {
                // TODO: Return/log exception
                return null;
            }
        }
        public static Person GetJson()
        {
            var person = new Person();
            person.FirstName = "John";
            person.LastName = "Doe";
            person.Orders = new List<Order>();
            person.Orders.Add(new Order() { Id = 1, Description = "..." });
            return person;
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Order> Orders { get; set; }
        }
        public class Order
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
