        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(int id)
        {
            var item = this.PeopleRepository.GetById(id);
            if (item == null)
            {
                return this.HttpNotFound();
            }
            return new ObjectResult(item);
        }
