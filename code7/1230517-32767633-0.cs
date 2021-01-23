    [HttpGet("getList")]
    public async Task<string> Get(string token, string page, string amount) {
        var t = Task<int>.Run(() => {
            return CustomerDA.getList(token, page, amount);
        });
        return await t;
    }
