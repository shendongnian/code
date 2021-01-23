    public partial class _Default : Page
    {
        public bool Loaded { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private async Task AsyncDatabind()
        {
            await Task.Delay(5000);
            Test.Text = "Hello!";
            Loaded = true;
        }
        protected void Panel_Load(object sender, EventArgs e)
        {
            if(IsPostBack && !Loaded)
                RegisterAsyncTask(new PageAsyncTask(AsyncDatabind));
        }
    }
