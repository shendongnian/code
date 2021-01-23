    private void incomes_Click(object sender, EventArgs e)
    {
        panel1.Controls.Clear();
        CreateTextBox("Name", 0);
        CreateTextBox("Sum",  80);
    }
    private void CreateTextBox(string text, int x)
    {
        TextBox textbox = new TextBox();
        textbox.Size = new Size(75, 23);
        textbox.Text = text;
        textBox.Location = new Point(x, 0);
        panel1.Controls.Add(textbox);
    }
