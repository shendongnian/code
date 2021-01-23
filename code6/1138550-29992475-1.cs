    int i = 0;
    public Form1() {
        InitializeComponent();
    }
    private void panel1_Paint(object sender, PaintEventArgs e) {
        DrawSlots(e.Graphics, Pens.Red);
    }
    void DrawLines(Graphics gObject, Pen pPen) {
        Point pPoint1 = new Point(this.Bounds.Width / 2, 0);
        Point pPoint2 = new Point(this.Bounds.Width / 2 - this.Bounds.Width / 4, 0);
        Point pPoint3 = new Point(this.Bounds.Width / 2 + this.Bounds.Width / 4, 0);
        Point pPoint1a = new Point(this.Bounds.Width / 2, 1000);
        Point pPoint2a = new Point(this.Bounds.Width / 2 - this.Bounds.Width / 4, 1000);
        Point pPoint3a = new Point(this.Bounds.Width / 2 + this.Bounds.Width / 4, 1000);
        gObject.DrawLine(pPen, pPoint1, pPoint1a);
        gObject.DrawLine(pPen, pPoint2, pPoint2a);
        gObject.DrawLine(pPen, pPoint3, pPoint3a);
    }
    void DrawSlots(Graphics gObject, Pen pPen) {
        int WindowWidth = this.Bounds.Width;
        int WindowHeight = this.Bounds.Height;
        int RectHeight, RectWidth;
        RectHeight = 550;
        RectWidth = 350;
        Rectangle Slot1 = new Rectangle(WindowWidth / 2 - WindowWidth / 4 - RectWidth / 2 + i, WindowHeight / 2 - RectHeight / 2, RectWidth, RectHeight);
        Rectangle Slot2 = new Rectangle(WindowWidth / 2 - RectWidth / 2, WindowHeight / 2 - RectHeight / 2, RectWidth, RectHeight);
        Rectangle Slot3 = new Rectangle(WindowWidth / 2 + WindowWidth / 4 - RectWidth / 2, WindowHeight / 2 - RectHeight / 2, RectWidth, RectHeight);
        gObject.DrawRectangle(pPen, Slot1);
        gObject.DrawRectangle(pPen, Slot2);
        gObject.DrawRectangle(pPen, Slot3);
    }
    private void timer1_Tick(object sender, EventArgs e) {
        i++;
        this.panel1.Invalidate();
    }
