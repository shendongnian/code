    private static async Task<T> SurroundWithTryCatch<T>(Func<Task> t, T response) where T : BaseResponse 
    {
        try
        {
            await t();
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Errors.Add(e.Message);
        }
        return response;
    }
    
    public async Task<CreateResponse> CreateAsync(CreateRequest request)
    {
        var response = new CreateResponse();
        return await SurroundWithTryCatch(async () =>
        {
            var newUser = new ApplicationUser { UserName = request.UserName, Email = request.Email };
            await Database.UserManager.CreateAsync(newUser, request.Password);
            //Some another logic...
            await Database.CommitAsync();
        }, response);
    }
