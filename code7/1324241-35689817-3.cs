    [Export( typeof( IMyPlugin ) )]
    internal class MyPlugin : IModule, IMyPlugin
    {
        private readonly IStatusBarManager _manager;
    
        [ImportingConstructor]
        public MyPlugin( [Import( AllowDefault = true )] IStatusBarManager manager )
        {
            _manager = manager;
            if( _manager != null )
            {
                _manager.Display( "Hi from MyPlugin!" );
            }
        }
    }
    
    [Export( typeof( IMyOtherPlugin ) )]
    internal class MyOtherPlugin : IModule, IMyOtherPlugin
    {
        private IStatusBarManager _statusManager;
    
        [Import( AllowDefault = true )]
        public IStatusBarManager StatusManager
        {
            get { return _statusManager; }
            private set
            {
                _statusManager = value;
                _statusManager.Display( "Hi from MyOtherPlugin!" );
            }
        }
    }
