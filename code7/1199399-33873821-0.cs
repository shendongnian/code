    public async Task<DataTablesResult> Get()
    {
        var result = new DataTablesResult();
        List<MyClass> myClass = await _Repository.GetListMyClass();
    
        result.Data = new List<dynamic>(myClass);
        var resultado = new
        {
            data = result.Data.ToArray()
        };
    
        return Ok(resultado);
    }
