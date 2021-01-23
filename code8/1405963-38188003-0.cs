    public override void OnStart(string[] args)
    {
        . . .
        if(somethingWrong)
            throw new Exception("something wrong");
    }
