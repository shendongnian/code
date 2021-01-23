container.RegisterType(typeof (IWindowService<>), typeof (WindowService<>))
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering dependencies ...");
            var container = new UnityContainer();
            container.RegisterType(typeof (IWindowService<>), typeof (WindowService<>));
            container.RegisterType<IWindow, Window>();
            container.RegisterType<IvmMain, ViewModel>(); // Or possibly RegisterInstance ?
            var foo = container.Resolve<IWindowService<IvmMain>>();
            
            Console.ReadKey();
        }
    }
    public interface IWindowService<T>
    {
    }
    public interface IWindow
    {
    }
    public interface IvmMain 
    {
    }
    public class ViewModel : IvmMain
    { 
    } 
    public class Window : IWindow 
    { 
    }
    public class WindowService<TViewModel> : IWindowService<TViewModel>
    {
        public WindowService(IWindow win, TViewModel vm)
        {
        }
    }
