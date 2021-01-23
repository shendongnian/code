    private void button20_Click(object sender, EventArgs e)
    {
        // lets add a few buttons..
        for (int i = 0; i < 20; i++)
        {
            Button btn = new Button();
            btn.Top = i * 25;
            btn.Parent = panel2;
        }
        // ..now let's enforce a scoll amount of 111 pixels:
        panel2.AutoScrollPosition =  new Point(panel2.AutoScrollPosition.X, 
                                                -panel2.AutoScrollPosition.Y + 111);
        // ..and add a few more buttons..
        for (int i = 20; i < 40; i++)
        {
            Button btn = new Button();
            btn.Top = i * 25;    // not good enough!
            // btn.Top = i * 25 + panel2.AutoScrollPosition.Y; // this will fix the problem!
            btn.Parent = panel2;
        }
    }
