    public void CallMethod(object service)
    {
        if (service is Localservice)
            (service as Localservice).CallMethod();
        else
            (service as Amazonservice).CallMethod();
    }
