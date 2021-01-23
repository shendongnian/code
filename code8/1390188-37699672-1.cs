    public interface IInterfaceMethod<out T0>
        where T0 : IInterface2
    {
        T0 GetterAndSetter { get; set; }
        void MethodParameter(T0 value);
        void MethodOutParameter(out T0 value);
    }
