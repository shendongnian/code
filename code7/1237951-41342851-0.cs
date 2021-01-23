    public interface IInterfaceName { }
    public class InterfaceImpl : IInterfaceName { }
    IUnityContainer container = new UnityContainer();
    container.RegisterType<IInterfaceName,InterfaceImp(typeof(InterfaceImpl).Name);
    IInterfaceName interfaceClass = container.Resolve<IInterfaceName(typeof(InterfaceImp).Name);
