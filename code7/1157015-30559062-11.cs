    private void Button1_MouseDown(object sender, MouseEventArgs e)
    {
        hitTest(sender as Button, e);
        if (sender != clickedButton)
            yourParent_MouseDown((sender as Button).Parent, ee);
        else // do your stuff
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        if (sender != clickedButton)
            yourParent_Click((sender as Button).Parent, e);
        else // do your stuff
    }
    private void Button1_MouseClick(object sender, MouseEventArgs e)
    {
        if (sender != clickedButton)
            yourParent_MouseClick((sender as Button).Parent, ee);
        else // do your stuff
    }
    private void Button1_MouseUp(object sender, MouseEventArgs e)
    {
        if (sender != clickedButton)
            yourParent_MouseUp((sender as Button).Parent, ee);
        else // do your stuff
    }
