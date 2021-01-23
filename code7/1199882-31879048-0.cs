    [HttpPut]
    public async Task UpdateAsync([FromBody] Company company)
    {
        if ((!ModelState.IsValid) || (company == null))
        {
            Context.Response.StatusCode = 400;
            return;
        }
        else
        {
            await _repository.UpdateAsync(company);
        }
    }
