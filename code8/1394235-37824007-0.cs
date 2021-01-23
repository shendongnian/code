    Rectangle rectangleObj;
    Bitmap background;
    Graphics scG;
    Pen myPen;
    private void Form1_Load(object sender, EventArgs e)
    {
        rectangleObj = new Rectangle(10, 10, 30, 30);
        background = new Bitmap(Width, Height);
        scG = Graphics.FromImage(background);
        myPen = new Pen(Color.Red, 3);
        BackgroundImage = background;
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        var point = PointToClient(Cursor.Position);
        rectangleObj.X = point.X - rectangleObj.Height / 2;
        rectangleObj.Y = point.Y - rectangleObj.Width / 2;
        scG.DrawEllipse(myPen, rectangleObj);
        Refresh();
    }
