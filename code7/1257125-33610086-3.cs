    public void InitializeProgram()
    {
        UserHelper.Repository = GetRepository(...);
    }
    public void MyFunction()
    {
        var userHelper = UserHelper.GetInstance()
        userHelper.SetUser(...);
    }
    public void MyOtherFunction()
    {
        UserHelper.GetInstance().Function1();
    }
