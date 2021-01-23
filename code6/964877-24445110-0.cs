    using System;
    using System.Collections.Generic;
    using System.Net;
    using RestSharp;
    
    namespace RestSharpMockaroo
    {
        public class MockarooColumnsObject
        {
            public string name { get; set; }
            public string type { get; set; }
            public object min { get; set; }
            public object max { get; set; }
            public int decimals { get; set; }
            public List<string> values { get; set; }
            public string format { get; set; }
        }
    
        public class MockarooResponseObject
        {
            public string yearsEmployed { get; set; }
            public string department { get; set; }
            public string dob { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<MockarooColumnsObject> lMockarooColumnsObject = new List<MockarooColumnsObject>();
                lMockarooColumnsObject.Add(new MockarooColumnsObject() { name = "yearsEmployed", type = "Number", min = 1, max = 30, decimals = 0 });
                lMockarooColumnsObject.Add(new MockarooColumnsObject() { name = "department", type = "Custom List", values = new List<string> { "R+D", "Marketing", "HR" } });
                lMockarooColumnsObject.Add(new MockarooColumnsObject() { name = "dob", type = "Date", min = "1/1/1950", max = "1/1/2000", format = "%m/%d/%Y" });
     
                RestClient MockarooClient = new RestClient("http://www.mockaroo.com/");
                RestRequest MockarooRequest = new RestRequest("api/generate.json?key=abcd1234", Method.POST);
                MockarooRequest.RequestFormat = DataFormat.Json;
                MockarooRequest.AddBody(lMockarooColumnsObject);
    
                IRestResponse<MockarooResponseObject> response = MockarooClient.Execute<MockarooResponseObject>(MockarooRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // OK 
                    Console.WriteLine("yearsEmployed = {0}", response.Data.yearsEmployed);
                    Console.WriteLine("department = {0}", response.Data.department);
                    Console.WriteLine("dob = {0}", response.Data.dob);
                }
                else
                {
                    // NOK
                    Console.Write("ERROR: {0}", response.Content);
                }
            }
        }
    }
