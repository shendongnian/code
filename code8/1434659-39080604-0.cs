    [HttpGet("{id}", Name = "GetTodo")]       //Name used when calling the api
    public IActionResult GetById(string id)
    {
        var item = TodoItems.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }
