        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult Get(int id)
        {
            Product product = null;
            if (!this.productRepository.TryGet(id, out product))
            {
                return NotFound();
            }
            return Ok(product);
        }
