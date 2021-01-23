    this.ButtonName.MouseHover += new System.EventHandler(Button_MouseHover);
    //...
    private void Button_MouseHover(object sender, EventArgs e)
    {
        varbtn = sender as Button;
        var your_color = btn.BackColor;
    }
