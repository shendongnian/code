    public interface IInterfaceMethod<out T0>
        where T0 : IInterface2
    {
        T0 GetterOnly { get; }
        T0 MethodReturnValue();
    }
