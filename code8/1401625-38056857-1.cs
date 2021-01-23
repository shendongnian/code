    public UIManagerLoginRegister loginRegisterPrefab;
    UIManagerLoginRegister loginRegister;
    void Start()
    {
        loginRegister= Instantiate(loginRegisterPrefab) as UIManagerLoginRegister;
    }
