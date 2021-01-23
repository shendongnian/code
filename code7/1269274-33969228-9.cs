    void button_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        //Instead put your logic here
        MessageBox.Show(string.Format("You clicked {0}", button.Text));
    }
