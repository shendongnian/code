    private CreateAccountController ctr;
    public void loadCreateAccountCtr()
    {
        // Create Controller
        ctr = new CreateAccountController();
        // Start Controller
        ctr.start();
        // Session is active
    }
    public void checkCredentials(string appNum)
    {
        if (ctr != null)
        {
            ctr.create();
        }
        else
        {
            //handle this case here
        }
    }
