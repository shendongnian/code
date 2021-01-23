    private static void CheckThenCall<T>(T param)
    {
        if (param is IHaveInterface)
        {
            Call(param as IHaveInterface);
        }
    }
    
    private static void Call<T>(T param) where T : IHaveInterface
    {
        Type typeOf = param.GetType();
    }
