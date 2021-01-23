    public async Task<object> Get([FromUri] Contract contract)
    {
        var result = await _invoker.Invoke(CreateDto<Query>(contract));
        return result as object;
    }
