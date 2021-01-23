     public MainWindow()
      {
       InitializeComponent();     
       LocationChanged += new EventHandler(Window_LocationChanged);
      }
    ChildWindow win = new ChildWindow();
       win.Owner = this;
       win.Show();
    private void Window_LocationChanged(object sender, EventArgs e)
      {
       Console.WriteLine("LocationChanged - ({0},{1})", this.Top, this.Left);
       foreach (Window win in this.OwnedWindows)
       {
        win.Top = this.Top + 100;
        win.Left = this.Left + 100;
       }
      }
