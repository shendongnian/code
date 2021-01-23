    DateTime dt = new DateTime.Now;
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        lblView.Text = string.Format("{0:mm\\:ss}", DateTime.Now - dt);
    }
