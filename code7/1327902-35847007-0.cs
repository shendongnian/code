        public partial class ApplicationShellView : Form, IApplicationShellView
        {
            private IApplicationShellController _controller;
            public ApplicationShellView()
            {
                InitializeComponent();
                init();
                //InitializeView()
            }
            
            private void init() {
                _controller = NinjectProgram.Kernel.Get<IApplicationShellController>();
                //Because your view knows the controller you can always pass himself as parameter or even use setter to inject
                //For example:  _controller.SetView1(this);
            }
            
            public void InitializeView()
            {
                dockPanel.Theme = vS2012LightTheme;
            }
        }
        public class ApplicationShellController : IApplicationShellController
        {
            
            //Implementes functionality for the MainForm.
            public ApplicationShellController()
            {
                //Also possible to add other controllers with DI
            }
        }
