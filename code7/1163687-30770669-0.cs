    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 20; x++)
            {
                messageControl1.Add(x.ToString("00") + ": Testing testing testing ...", MessageControl.BubblePositionEnum.Right);
                messageControl1.Add(x.ToString("00") + ": Testing with variable length strings.  This one is longer!", MessageControl.BubblePositionEnum.Right);
                messageControl1.Add(x.ToString("00") + ": Testing is fun.", MessageControl.BubblePositionEnum.Left);
            }
        }
    }
    public class MessageControl : FlowLayoutPanel 
    {
        public List<Message> Messages { get; private set; }
        private Color _LeftBubbleColor = Color.FromArgb(217, 217, 217);
        private Color _RightBubbleColor = Color.FromArgb(192, 206, 215);
        private Color _LeftBubbleTextColor = Color.FromArgb(52, 52, 52);
        private Color _RightBubbleTextColor = Color.FromArgb(52, 52, 52);
        private bool _DrawArrow = true;
        private int _BubbleIndent = 40;
        private int _BubbleSpacing = 10;
        public enum BubblePositionEnum { Left, Right }
        public Color LeftBubbleColor { get { return _LeftBubbleColor; } set { _LeftBubbleColor = value; } }
        public Color RightBubbleColor { get { return _RightBubbleColor; } set { _RightBubbleColor = value; } }
        public Color LeftBubbleTextColor { get { return _LeftBubbleTextColor; } set { _LeftBubbleTextColor = value; } }
        public Color RightBubbleTextColor { get { return _RightBubbleTextColor; } set { _RightBubbleTextColor = value; } }
        public int BubbleIndent { get { return _BubbleIndent; } set { _BubbleIndent = value; } }
        public int BubbleSpacing { get { return _BubbleSpacing; } set { _BubbleSpacing = value; } }
        public bool DrawArrow { get { return _DrawArrow; } set { _DrawArrow = value; } }
        public MessageControl()
        {
            this.Messages = new List<Message>();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.BackColor = Color.Orange;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.AutoScroll = true;
        }
        public void Remove(Message message)
        {
            this.Messages.Remove(message);
            this.Controls.Remove(message);   
            this.Invalidate();
            this.Refresh();
        }
        public void Remove(Message[] messages)
        {
            this.SuspendLayout();
            foreach (Message m in messages)
            {
                Messages.Remove(m);
                this.Controls.Remove(m);
            }
            this.ResumeLayout();
            this.Invalidate();
            this.Refresh();
        }
        public void Add(string Message, BubblePositionEnum Position)
        {
            Message b = new Message(this, Message, Position);
            b.DrawBubbleArrow = _DrawArrow;
            b.Width = this.ClientSize.Width;
            Messages.Add(b);
            this.Controls.Add(b);
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            this.ResizeMessages();
            base.OnLayout(levent);
        }
        protected override void OnResize(System.EventArgs e)
        {
            this.ResizeMessages();
            base.OnResize(e);
        }
        private void ResizeMessages()
        {
            this.SuspendLayout();
            foreach (Message m in this.Messages)
            {
                m.Width = this.ClientSize.Width - 9;
            }
            this.ResumeLayout();
        }
        public class Message : Control
        {
            private MessageControl _mc;
            private GraphicsPath Shape;
            private Color _TextColor = Color.FromArgb(52, 52, 52);
            private Color _BubbleColor = Color.FromArgb(217, 217, 217);
            private bool _DrawBubbleArrow = true;
            private BubblePositionEnum _BubblePosition = BubblePositionEnum.Left;
            public override Color ForeColor { get { return this._TextColor; } set { this._TextColor = value; this.Invalidate(); } }
            public BubblePositionEnum BubblePosition { get { return this._BubblePosition; } set { this._BubblePosition = value; this.Invalidate(); } }
            public Color BubbleColor { get { return this._BubbleColor; } set { this._BubbleColor = value; this.Invalidate(); } }
            public bool DrawBubbleArrow { get { return _DrawBubbleArrow; } set { _DrawBubbleArrow = value; Invalidate(); } }
            private Message() { }
            public Message(MessageControl mc, string Message, BubblePositionEnum Position)
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
                this.UpdateStyles();
                this._mc = mc;
                this._BubblePosition = Position;
                this.Text = Message;
                this.BubbleColor = (Position == BubblePositionEnum.Right ? mc.RightBubbleColor : mc.LeftBubbleColor);
                this.BackColor = this.BubbleColor;
                this.ForeColor = (Position == BubblePositionEnum.Right ? mc.RightBubbleTextColor : mc.LeftBubbleTextColor);
                this.Font = new Font("Segoe UI", 10);
                this.Size = new Size(152, 38);
                this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            }
            protected override void OnResize(System.EventArgs e)
            {
                base.OnResize(e);
                Shape = new GraphicsPath();
                if (BubblePosition == BubblePositionEnum.Left)
                {
                    Shape.AddArc(9, 0, 10, 10, 180, 90);
                    Shape.AddArc(Width - 10 - this._mc.BubbleIndent, 0, 10, 10, -90, 90);
                    Shape.AddArc(Width - 10 - this._mc.BubbleIndent, Height - 11, 10, 10, 0, 90);
                    Shape.AddArc(9, Height - 11, 10, 10, 90, 90);
                }
                else
                {
                    Shape.AddArc(this._mc._BubbleIndent, 0, 10, 10, 180, 90);
                    Shape.AddArc(Width - 18, 0, 10, 10, -90, 90);
                    Shape.AddArc(Width - 18, Height - 11, 10, 10, 0, 90);
                    Shape.AddArc(this._mc._BubbleIndent, Height - 11, 10, 10, 90, 90);
                }
                if (_DrawBubbleArrow == true)
                {
                    Point[] p;
                    if (_BubblePosition == BubblePositionEnum.Left)
                    {
                        p = new Point[] {
                            new Point(9, 9),
                            new Point(0, 15),
                            new Point(9, 20)
                        };                      
                    }
                    else
                    {
                        p = new Point[] {
                            new Point(Width - 8, 9),
                            new Point(Width, 15),
                            new Point(Width - 8, 20)
                        };
                    }
                    Shape.AddPolygon(p);
                }
                Shape.CloseAllFigures();
                this.Region = new Region(Shape);
                this.Invalidate();
                this.Refresh();
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var G = e.Graphics;
                int RenderWidth = this.Width - 10 - this._mc.BubbleIndent;
                SizeF s = G.MeasureString(Text, Font, RenderWidth);
                this.Height = (int)(Math.Floor(s.Height) + 10);
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the string specified in 'Text' property
                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    if (_BubblePosition == BubblePositionEnum.Left)
                    {
                        G.DrawString(Text, Font, brush, new Rectangle(13, 4, RenderWidth, Height - 5));
                    }
                    else
                    {
                        G.DrawString(Text, Font, brush, new Rectangle(this._mc.BubbleIndent + 5, 4, RenderWidth, Height - 5));
                    }
                }
            }
        }
    }
