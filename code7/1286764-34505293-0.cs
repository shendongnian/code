     [HttpGet]
        public IActionResult Get([FromUri]DateTime startDate,[FromUri] DateTime endDate, [FromUri]int offset = 0, [FromUri]string type = "defaultType")
        {
            List<DateTime> sampleDates = new List<DateTime>()
            {
                new DateTime(2015, 1, 22),
                new DateTime(2015, 2, 22),
                new DateTime(2015, 3, 22),
                new DateTime(2015, 4, 22),
            };
        
            return Ok(sampleDates);
        }
