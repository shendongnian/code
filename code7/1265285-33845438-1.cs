    string previousText;
    public Form1()
    {
        InitializeComponent();
        previousText = String.Empty;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int dummy, changeLenght, position;
        if (!String.IsNullOrWhiteSpace(textBox1.Text) && !int.TryParse(textBox1.Text, out dummy))
        {
            position = textBox1.SelectionStart;
            changeLenght = textBox1.TextLength - previousText.Length;
            textBox1.Text = previousText;
            textBox1.SelectionStart = position - changeLenght;
        }
        else
        {
            previousText = textBox1.Text;
        }
    }
