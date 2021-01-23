    internal class TypeDefinedByArgumentInstanceProvider : StandardInstanceProvider
    {
        protected override Type GetType(MethodInfo methodInfo, object[] arguments)
        {
            return (Type)arguments.Single();
        }
    }
    kernel.Bind<IFooFactory>()
        .ToFactory(() => new TypeDefinedByArgumentInstanceProvider());
