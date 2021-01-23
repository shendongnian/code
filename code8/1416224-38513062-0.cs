        [HttpGet]
        [Route("api/values/{number}/{source}/{aux}/{destination}")]
        public string Get(int number, string source, string aux, string destination)
        {
            Hanoi h = new Hanoi();
            return h.MoveDisks(number, source, aux, destination);
        }
