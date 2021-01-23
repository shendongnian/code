    for (int i = 0; i < tabControl1.TabCount; i++)
    {
        foreach (Control child in tabControl1.TabPages[i].Controls.OfType<TextBox>())
        {
            TextBox textBox = (TextBox) child;
            textBox.Text = "";
        }
    }
