    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        // ... your other code
        
        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            equal.PerformClick();
        if (e.KeyCode == Keys.Back)
            button17.PerformClick();
    }
