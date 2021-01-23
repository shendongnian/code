    public class ServiceGUI : System.Windows.Forms.Form
    {
        private MyService _myService;
        public ServiceGUI(MyService service)
        {
            _myService = service;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _myService.DoStart(null);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _myService.DoStop();
        }        
    }
