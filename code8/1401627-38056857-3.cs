    public GameObject loginRegisterPrefab;
    UIManagerLoginRegister loginRegister;
    void Start()
    {
        GameObject tempObjct = Instantiate(loginRegisterPrefab) as GameObject;
        loginRegister = tempObjct.GetComponent<UIManagerLoginRegister>();
    }
