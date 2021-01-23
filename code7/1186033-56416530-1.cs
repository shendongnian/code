public static class EagerSingleton
{
    public static IBindingNamedWithOrOnSyntax<T> AsEagerSingleton<T>(this IBindingInSyntax<T> binding)
    {
        var r = binding.InSingletonScope();
        
        binding.Kernel.Bind<IEagerSingleton>().To<EagerSingleton<T>>().InSingletonScope();
        return r;
    }
}
public interface IEagerSingleton { }
public class EagerSingleton<TComponent> : IEagerSingleton
{
    public EagerSingleton(TComponent component)
    {
        // do nothing. DI created the component for this constructor.
    }
}
public class EagerSingletonSvc
{
    public EagerSingletonSvc(IEagerSingleton[] singletons)
    {
        // do nothing. DI created all the singletons for this constructor.
    }
}
After you've created your kernel, add a single line:
kernel.Get<EagerSingletonSvc>(); // activate all eager singletons
You use it in a module like this:
Bind<UnhandledExceptionHandlerSvc>().ToSelf().AsEagerSingleton();
