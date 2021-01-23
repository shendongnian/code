        [HttpGet("{id}", Name = "GetPurchase")]
        public IActionResult Get(int id)
        {
            var item = this.PurchaseRepository.GetById(id);
            if (item == null)
            {
                return this.HttpNotFound();
            }
            return new ObjectResult(item);
        }
