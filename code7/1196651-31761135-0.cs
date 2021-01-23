    //Upper and lower case characters
    if (!e.Shift && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
       textBox2.Text += (char)(e.KeyValue + 32);
    else if (e.Shift && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
        textBox2.Text += (char)(e.KeyValue);
    else if (e.Shift || e.Alt || e.Control)
        textBox2.Text += "";
