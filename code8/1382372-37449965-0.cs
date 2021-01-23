    frm.HelpButtonClicked += HelpButtonClicked;
    
    static void HelpButtonClicked(object sender, CancelEventArgs e)
    {
        MessageBox.Show("Help Button Clicked");//Works :)
    }
