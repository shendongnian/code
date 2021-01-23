    void bClick(object sender, EventArgs e)
    {
        Button btn1 = (Button)sender;
        string buttonID = btn1.ID;
        MessageBox.Show("you clicked on a Button :D");
    }
