    List<TextBox> box2;
    private void Form1_Load(object sender, EventArgs e)
    {
        // Using LINQ to extract all the controls of type TextBox 
        // having a name starting with the characters textBox2 
        // BE AWARE - Is case sensitive -
        box2 = this.Controls.OfType<TextBox>()
                            .Where(x => x.Name.StartsWith("textBox2")).ToList();
        // Set to each textbox in the list the event handler
        foreach(TextBox t in box2)
            t.TextChanged += textBox_TC;
    }
