    public IQueryable<MyModel> GetAllMyInfo()
    {
        // Get the current user
        var currentUser = User as ServiceUser;
        if(currentUser == null) {
            throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest)
            // Or to add a content message:
            throw new HttpResponseException(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest) {
                Content = new System.Net.Http.StringContent("Database has already been created.")
            });
        }
        var ownerId = currentUser.Id;
    
        return Query().Where(s => s.OwnerId == ownerId); 
    }
