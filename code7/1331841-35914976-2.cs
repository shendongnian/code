    private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if(e.KeyData == Keys.Tab)
        {
            MessageBox.Show("Tab");
            e.IsInputKey = true;
        }
        if (e.KeyData == (Keys.Tab | Keys.Shift))
        {
            MessageBox.Show("Shift + Tab");
            e.IsInputKey = true;
        }
    }
