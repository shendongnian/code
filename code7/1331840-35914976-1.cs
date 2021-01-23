    private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {
            MessageBox.Show("Tab Pressed!");
            e.IsInputKey = true;
        }
    }
