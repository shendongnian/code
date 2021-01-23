    public UC()
    {
        BorderStyle = BorderStyle.FixedSingle;
        MyControl.ImageLocation = "http://i.stack.imgur.com/CR5ih.png";
        MyControl.Location = new Point(100, 100);
        this.Controls.Add(MyControl);
        MyControl.MouseHover += ShowToolTip;
        //Subscribe MouseLeave and hide the tooltip there
        MyControl.MouseLeave += MyControl_MouseLeave;
    }
    void MyControl_MouseLeave(object sender, EventArgs e)
    {
        ToolTip.Hide(MyControl);
    }
