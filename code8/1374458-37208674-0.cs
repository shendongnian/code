    private void IsKeyPressNumber(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (!(e.KeyChar >= '0' && e.KeyChar <= '9'))
            e.Handled = true;
    }
    
    this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsKeyPressNumber);
