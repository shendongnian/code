    public void CallMethod(object service)
    {
        if (service is Localservice)
            ((Localservice)service).CallMethod();
        else
            ((Amazonservice)service).CallMethod();
    }
