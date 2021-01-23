    public partial class Form2 : Form
    {
        private FlowLayoutPanel flp = new FlowLayoutPanel();
        public Form2(List<IPAddress> addresses)
        {
            InitializeComponent();    
    
            flp.AutoScroll = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Location = new System.Drawing.Point(12, 67);
            flp.AutoSize = false;
            flp.Height = 600;
            flp.Width = 1110;
            flp.WrapContents = false;
        }
    }
