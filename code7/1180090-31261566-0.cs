    private void button1_click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        isClicked = !isClicked;
        btn.BackgroundImage = isClicked? image1 : image2; // or use BackColor
    }
