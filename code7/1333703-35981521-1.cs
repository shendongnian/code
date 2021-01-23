        public Result Login(string username, string password)
        {
            int token=1;
            Result response = new Result();
            if (user != null && user.Password == password)
            {
                response.message = "Success";
                response.statusCode = "200";
                response.value = token;
            }
            else
            {
                response.message = "Fail";
                response.statusCode = "401";
                response.value = null;
            }
            return response;
        }
        public class Result
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public object value { get; set; }
        }
