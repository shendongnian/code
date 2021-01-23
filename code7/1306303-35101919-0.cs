    private void btnAdd_Click(object sender, EventArgs e)
    {
        TextBox textbox = new TextBox();
        .....
        textbox.Name = "textbox_" + (count + 1);
        textbox.Tag = "SPEECH";
        ....
        panel1.Controls.Add(textbox);
    }
