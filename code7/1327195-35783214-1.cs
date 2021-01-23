    public HttpResponseMessage Post(UserModel userModel)
    {
       // ignore provided userModel.Id
    }
    public HttpResponseMessage Put(int id, UserModel userModel)
    {
       if(id != userModel.Id)
       {
           // return bad request response
       }
    }
