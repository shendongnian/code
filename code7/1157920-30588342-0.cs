    /// <summary>
    /// form load
    /// </summary>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    
        // create textbox
        TextBox textBox = new TextBox()
        {
            Location = new Point(8, 8),
            Text = "Write some text here and press [Enter]"
        };
        this.Controls.Add(textBox);
    
        // bind textbox KeyDown event
        textBox.KeyDown += textBox_KeyDown;
    }
    
    /// <summary>
    /// KeyDown event handler
    /// </summary>
    void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // [Enter] key pressed
            TextBox tb = (TextBox)sender;
            string text = tb.Text;
            MessageBox.Show(string.Format("You entered: '{0}'", text));
            tb.Clear();
        }
    }
