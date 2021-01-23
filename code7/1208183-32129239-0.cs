        public string GetA()
        {
            return "Hello from GetA";
        }
        public string GetB(int id)
        {
            return "Hello from GetB";
        }
        [Route("api/all/{controller}/{id}")]
        [Route("api/all/{controller}")]
        public string GetC(int id= 0)
        {
            return "Hello from GetC";
        }
