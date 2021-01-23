    public async Task<E> SendCommandAsync(C command)
    {
        var result = await _SendCommandAndRetrieveResponseAsync(command);
        return result.Item1;
    }
