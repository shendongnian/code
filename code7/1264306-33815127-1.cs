    private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if(e.KeyCode== Keys.Enter)
        {
            MessageBox.Show("Enter");
        }
        if (e.KeyCode == Keys.Space)
        {
            MessageBox.Show("Space");
        }
    }
