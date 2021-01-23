    [HttpGet]
    [ODataRoute("Books({key})/Press/{pName:dynamicproperty}")]
    public IHttpActionResult XxxxDynamicPropertyXxxx([FromODataUri] string key, [FromODataUri] string pName)
    {
        Book book = _books.FirstOrDefault(e => e.ISBN == key);
        if (book == null)
        {
            return NotFound();
        }
        
        object value;
        if (!book.Press.DynamicProperties.TryGetValue(pName, out value))
        {
           return NotFound();
        }
    
         return Ok(value, value.GetType());
    }
        
