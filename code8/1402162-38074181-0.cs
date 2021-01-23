    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            GetPoint();
        }
        public async void GetPoint()
        {
            var point = await RetrivePointAsync();
            MessageBox.Show(point.ToString());
        }
        public Task<Point> RetrivePointAsync()
        {
            return Task.Factory.FromAsync<Point>(
                 (callback, state) => new Handler(this, callback),
                 x => ((Handler)x).Point, null);
        }
    }
    class Handler : IAsyncResult
    {
        AsyncCallback _calback;
        public Point Point { get; set; }
        public object AsyncState { get { return null; } }
        public bool CompletedSynchronously { get { return false; } }
        public bool IsCompleted { get; set; }
        public WaitHandle AsyncWaitHandle { get { return null; } }
        public Handler(Control control, AsyncCallback calback)
        {
            _calback = calback;
            control.MouseDown += control_MouseDown;
        }
        void control_MouseDown(object sender, MouseEventArgs e)
        {
            Point = e.Location;
            IsCompleted = true;
            _calback(this);
        }
    }
