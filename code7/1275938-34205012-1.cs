        [HttpGet]
        public IHttpActionResult Multiply([FromUri] int[] numbers)
        {
            int result = 0;
            if(numbers.Length > 0)
            {
                result = 1;
                foreach (int i in numbers)
                {
                    result = result * i;
                }
            }
            return Ok(result);
        }
    }
