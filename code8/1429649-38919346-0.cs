    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check if pressed key is `Enter` key
        if (e.KeyChar == (char)Keys.Return){
             button1.PerformClick();
        }
    }
