    private Timer _timer;
    private PictureBox _sender;
    private int _clicks;
    public Form1()
    {
        InitializeComponent();
        pictureBox.Click += picutureClick;
        pictureBox.DoubleClick += (s, e) =>
                                        {
                                            // do your double click handling
                                            _clicks = 0;
                                        };
        
        // this Interval comes from trail and error, it's a balance between lag and  
        // correctness. To play safe, you can use SystemInformation.DoubleClickTime,
        // but may introduce a bit long lagging after you click and before you
        // see the effects.
        _timer = new Timer {Interval = 75}; 
        _timer.Tick += (s, e) =>
                            {
                                if (_clicks < 2)
                                {
                                    ClickHandler(_sender);
                                }
                                _clicks = 0;
                                _timer.Stop();
                            };
    }
    private void picutureClick(Object sender, EventArgs e)
    {
        _clicks++;
        _sender = (PictureBox) sender;
            
        if (_clicks == 1)
        {
            _timer.Start();
        }
    }
    private void ClickHandler(PictureBox picture)
    {
        if (picture.BorderStyle == BorderStyle.None)
        {
            picture.InvokeIfRequired(c => (c as PictureBox).BorderStyle = BorderStyle.Fixed3D);
            picture.BackColor = Color.Red;
        }
        else
        {
            picture.InvokeIfRequired(c => (c as PictureBox).BorderStyle = BorderStyle.None);
            picture.BackColor = Color.White;
        }
    }
