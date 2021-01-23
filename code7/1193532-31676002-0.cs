        [HttpGet]
        public string Test([FromUri]TestViewModel email)
        {
            if (ModelState.IsValid)
            {
                return "ok";
            }
            return "not ok";
        }
