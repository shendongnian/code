    private int _textBoxCounter;
    private TextBox _textBoxCurrentResizing;
    public Form1()
    {
        InitializeComponent();
        pictureBox1.MouseDown += PictureBox1OnMouseDown;
        pictureBox1.MouseUp += PictureBox1OnMouseUp;
        pictureBox1.MouseMove += PictureBox1OnMouseMove;
    }
    public Point RelativeMousePosition { get { return PointToClient(MousePosition); } }
    private void PictureBox1OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
    {
        ResizeTextBox();
    }
    private void PictureBox1OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
    {
        EndResizeTextBox();
    }
    private void PictureBox1OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
    {
        var tb = CreateTextBox();
        StartResizeTextBox(tb);
    }
    private TextBox CreateTextBox()
    {
        var tb = new TextBox
        {
            Location = RelativeMousePosition,
            Size = new Size(100, 20),
            Multiline = true,
            Name = "textBox" + _textBoxCounter++,
        };
        pictureBox1.Controls.Add(tb);
        return tb;
    }
    private void StartResizeTextBox(TextBox tb)
    {
        _textBoxCurrentResizing = tb;
    }
    private void ResizeTextBox()
    {
        if (_textBoxCurrentResizing == null) return;
        var width = Math.Abs(_textBoxCurrentResizing.Left - RelativeMousePosition.X);
        var height = Math.Abs(_textBoxCurrentResizing.Top - RelativeMousePosition.Y);
        _textBoxCurrentResizing.Size = new Size(width, height);
    }
    private void EndResizeTextBox()
    {
        _textBoxCurrentResizing = null;
    }
