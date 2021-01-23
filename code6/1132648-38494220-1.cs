    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public void KeepReportMousePos()
            {
                //Endless Report Mouse position
                Task.Factory.StartNew(() =>
                {
                    while(true){
                        this.Dispatcher.Invoke(
                            DispatcherPriority.SystemIdle,
                            new Action(() =>
                            {
                                GetCursorPos();
                            }));
                    }
                });
            }
            public void GetCursorPos()
            {
                //get the mouse position and show on the TextBlock
                System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
                TBK.Text = p.X + " " + p.Y;
            }
    
            private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
            {
                //invoke mouse position detect when wheel the mouse
                KeepReportMousePos();
            }
        }
