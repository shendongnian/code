    public static GuardArgument<TOut> As<TOut>(this IGuardArgument guardArgument)
        where TOut : class
    {
        // Check cast is OK, otherwise throw exception
        return new GuardArgument<TOut>(guardArgument.Value as TOut, guardArgument.Name);
    }
