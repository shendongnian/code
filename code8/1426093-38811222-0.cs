    private readonly string _fileName;
    
    public Form1(string fileName)
    {
      InitializeComponent();
      _fileName = fileName;
      richTextBox1.Text = File.ReadAllText(_fileName);
      Text = _fileName.Split(new[] {@"\"}, StringSplitOptions.None).Last();
    }
    
    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.S && e.Control)
      {
        if (_fileName == "")
        {
          richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);
        }
      }
    }
