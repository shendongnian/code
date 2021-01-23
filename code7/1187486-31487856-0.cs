    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Up)
            MessageBox.Show(string.Format("Ctrl+{0}",e.KeyCode.ToString()));
        else if (e.Control && e.KeyCode == Keys.Down)
            MessageBox.Show(string.Format("Ctrl+{0}", e.KeyCode.ToString()));
    }
