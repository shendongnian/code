    ...
        try
        {
        	await ADClient.Users.AddUserAsync(newUser);
        	return Result.Ok();
        }
        catch (DataServiceRequestException ex)
        {
        	var innerException = ex.InnerException;
        	var error = JsonConvert.DeserializeObject<ODataError>(innerException.Message);
        	return Result.Fail(new Error(error.Error.Message.Value, error.Error.Code, ex));
        }
