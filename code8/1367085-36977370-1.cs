        [WebMethod]
        public static string Notify(string Application, string order_reference, string new_status)
        {
            Response res = new Response();
            res.Application = Application;
            res.order_reference = order_reference;
            res.new_status = new_status;
            return "it worked";
        }
        public class Response
        {
            public string Application { get; set; }
            
            public string order_reference { get; set; }
            public string new_status { get; set; }
        }
