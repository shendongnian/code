        public class Mes
        {
            public string message { get; set; }
        }
        // GET api/My
        public Mes Get()
        {
            return new Mes { message = "thanks" };
          
           // return "Hello from custom controller!";
        }
        // POST api/My
        public Mes Post(Mes chal)
        {
            return new Mes { message = chal.message + "asnwer" };
            // return "Hello from custom controller!";
        }
    }
