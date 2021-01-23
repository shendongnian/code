    public partial class dial01Form : Form
    {
        private Timer timer01 = new Timer();
        int y = 0;      // Rotation value
        
        public dial01Form()
        {
            // Establishes size of Dial01Form
            this.Width = 500;
            this.Height = 500;
            // Actvates timer and sets interval
            timer01.Enabled = true;
            timer01.Tick += onTimer;
            timer01.Interval = 20;
            timer01.Start();
            // handle the paint event
            this.Paint += OnPaint;
            // Initializes form components
            InitializeComponent();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        { 
            // all painting here, targeting e.Graphics
            e.Graphics.Clear(SystemColors.Control);
            Image dial01Outline = Dial01.Properties.Resources.DialOutline250x250;
            e.Graphics.DrawImage(dial01Outline, (ClientSize.Width / 2) - 100, 
                (ClientSize.Height / 2) - 100);
            drawPointer(e.Graphics, trackBar1.Value);
        }
        private void onTimer(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }
        public int drawPointer(Graphics g1, int trkBarValue)
        {
            // elided: same code as before, but using the g1 parameter instead of a field
        }
    }
