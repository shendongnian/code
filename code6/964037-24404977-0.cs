    bool sizing = false;
    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
        if (!sizing) return;
        if (sizing) {sizing = false; /*do your stuff*/ }
    }
    private void Form1_Resize(object sender, EventArgs e)
    {
        sizing = true;
    }
