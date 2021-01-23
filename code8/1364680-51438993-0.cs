    public interface INavigator
    {
        void Navigate<T>();
    }
    public class Navigator : INavigator
    {
        private ShellViewModel _shellview;
        public Navigator(ShellViewModel shellview) //where ShellViewModel:IConductor
        {
            _shellview = shellview;
        }
        public void Navigate<T>()
        {
           //you can inject the IOC container or a wrapper for the same from constructor
           //and use that to resolve the vm instead of this
            var screen = IoC.Get<T>(); 
            _shellview.ActivateItem(screen);
        }
    }
