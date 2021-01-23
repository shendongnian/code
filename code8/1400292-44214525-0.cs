    // GET: api/customers/{id}
    [HttpGet("{id}", Name = "GetCustomer")]
    public IActionResult GetById(int id)
    {
        var customer = _customersService.GetCustomerById(id);
        
    	if (customer == null)
        {
    		return NotFound("Customer doesn't exist");        
        }
    	
        return Ok(customer);
    }
