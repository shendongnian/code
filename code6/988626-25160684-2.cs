    MethodInfo lockmethod = wicBitmapNativeMethodsClass.GetMethod("Lock", BindingFlags.Static |   BindingFlags.NonPublic);
    private void PositionInteropFormOverRender()
    {
        if (_interopForm == null) return;
        Window currentWindow = Window.GetWindow(this);
        FrameworkElement firstchild = this.Content as FrameworkElement;
        if (firstchild != null)
        {
            Point interopRenderScreenPoint = currentWindow.PointToScreen(new Point());
            _interopForm.Left = (int)interopRenderScreenPoint.X;
            _interopForm.Top = (int)interopRenderScreenPoint.Y;
            _interopForm.Width = (int)firstchild.RenderSize.Width;
            _interopForm.Height = (int)firstchild.RenderSize.Height;
        }
    }
    private void _host_Loaded(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
        browser.Navigate("http://www.youtube.com");
        browser.Width = 700;
        browser.Height = 500;
        browser.Dock = System.Windows.Forms.DockStyle.Fill;
        _host.Child = browser;
    }
    private void InitializeInteropForm()
    {
        if (_winformControl == null) return;
        if (_interopForm != null)
        {
            TearDownInteropForm();
        }
        _interopForm = new InteropForm();
        _interopForm.Opacity = 0.5;
        _interopForm.Controls.Add(_winformControl);
        _interopForm.Width = _winformControl.Width;
        _interopForm.Height = _winformControl.Height;
    }
