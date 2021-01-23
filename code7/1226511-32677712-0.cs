    private void button1_Click(object sender, RibbonControlEventArgs e) 
    {
        var mailItem = ((Inspector) e.Control.Context).CurrentItem;
        MessageBox.Show(mailItem.Subject);
        MessageBox.Show(mailItem.Body);
    }
