    bool isAKeyDown = false;
    private void key_Down(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Key.A && !isAKeyDown )
        {
            isAKeyDown = true;
            // Do Stuff
        }
    }
    private void key_Up(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Key.A)
        {
            isAKeyDown = false;
        }
    }
