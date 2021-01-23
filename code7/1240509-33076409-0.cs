    public ActionResult Edit(Int32? id) {
        // Repeat the below logic for each action you want access-control in, ensure it is also in your POST handlers too.
        if( !this.IsAuthorized() ) return this.Http401();
    }
    protected boolean IsAuthorized() {
        if( this.Request.User.Identity.Name == "someoneIDontLike" ) return false;
        return true;
    }
    protected ActionResult Http401(String message) {
        this.Response.StatusCode = 401;
        // This requires you to create your own custom HTTP 401 "Unauthorized" view file and viewmodel
        return this.View( new Http401ViewModel(message) );
    }
