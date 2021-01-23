    foreach (var button in this.Find<Button>())
    {
        button.MouseEnter += button_MouseEnter;
    }
    ...
    private void button_MouseEnter(object sender, MouseEventArgs e)
    {
        // Do stuff
    }
