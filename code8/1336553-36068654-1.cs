    //on your form_load or on the constructor...
    foreach (Control c in this.Controls)
    {
        Button btn = c as Button;
        if(c == null)
            continue;
        c.Click += handle_click;
    }
    //on your form class
    void handle_click(object sender, EventArgs e)
    {
        Table ss = new Table();
        Hide();
        ss.ShowDialog();
    }
