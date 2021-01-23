    button.Click += new EventHandler(button_Click);
    private void button_Click(object sender, EventArgs e)
    {
        if (button.Visibility == Visibility.Visible)
            button.Visibility = Visibility.Collapsed;
        else
            button.Visibility = Visibility.Visible;
    }
