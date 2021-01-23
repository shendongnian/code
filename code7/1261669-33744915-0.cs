    private void addNewTextbox(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var textBoxes = button.Tag as List<TextBox>;
        if (textBoxes == null)
            button.Tag = textBoxes = new List<TextBox>();
        var textBox = new TextBox();
        textBoxes.Add(textBox);
        textBox.Location = new Point(100 * textBoxes.Count, button.Top);
        textbox.Size = new Size(40, 50);
        this.Controls.Add(textBox);
    }
