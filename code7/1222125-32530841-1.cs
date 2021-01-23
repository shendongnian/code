    private readonly Point _lowerRightCorner;
    public frmDetectTextBoxScroll()
    {
        InitializeComponent();
        _lowerRightCorner = new Point(richTextBox1.ClientRectangle.Right,
                                      richTextBox1.ClientRectangle.Bottom);
    }
    private void richTextBox1_VScroll(object sender, EventArgs e)
    {
        int index = richTextBox1.GetCharIndexFromPosition(_lowerRightCorner);
        if (index == richTextBox1.TextLength - 1) {
            // Enable your checkbox here
        }
    }
