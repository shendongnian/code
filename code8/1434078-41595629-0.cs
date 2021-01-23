    [HttpGet("{id}", Name = "GetHero")]
        public IActionResult GetById(string id)
        {
            var hero = Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            return new ObjectResult(hero);
        }
