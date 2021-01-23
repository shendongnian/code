    public HttpResponseMessage Get(int id)
    {
        var user = (User)WebSession.CurrentUser;
        
        var mTrans = mTransLMgr.InitializeMTrans(user.currentSelectedEntity.Value);        
        mTransLMgr.AccNum = TController.GetAccountNumberBasedOnPrivilage(x,y);            
        // return ok with the model serialized on the response body
        Request.CreateResponse(HttpStatus.Ok, mTransLMgr);    
    } 
