        [HttpPost]
        [ODataRoute("GetEvenNumbers")]
        public IHttpActionResult GetEvenNumbers(ODataActionParameters parameter)
        {
            IEnumerable<int> numbers = parameter["numbers"] as IEnumerable<int>;
            List<int> evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return Ok(evenNumbers);
        }
