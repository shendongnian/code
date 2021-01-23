    public ActionResult PasswordInput(string password)
    {
        FormInputs pss = new FormInputs();
        pss.passWord = password;
        MyViewModel mvm = new MyViewModel(){input = pss, isList = false}
        return this.View("Index", mvm); 
    }
