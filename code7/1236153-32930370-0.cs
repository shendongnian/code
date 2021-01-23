    namespace CustomControlTest
    {
        public partial class MyTextField : TextBox
        {
            public MyTextField()
            {
                InitializeComponent();
                GhostText = this.Text;
                if(GhostText == null)
                {
                    this.Text = "Orange";
                }                
            }
    
            public string GhostText { get; set; }
    
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
            }
        }
    }
