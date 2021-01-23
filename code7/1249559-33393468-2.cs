    public class MyViewModel
    {
        private IWindowService _WindowService;
        public MyViewModel(IWindowService windowService)
        {
            _WindowService = windowService;
        }
        ...
    }
