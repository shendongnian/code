    public interface IShellService
    {
        void ShowShell();
    }
    public class ShellService : IShellService
    {
        private IUnityContainer _unityContainer;
        private IRegionManager _regionManager;
    
        public ShellService(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = _regionManager;
    
        }
    
        public void ShowShell()
        {
            shell = _container.Resolve<Shell>();
    
            var scopedRegion = _regionManager.CreateRegionManager();
    
            RegionManager.SetRegionManager(shell, scopedRegion);
    
            shell.Show();
        }
    }
