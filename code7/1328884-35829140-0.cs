    private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && e.Control)
        {
            // Stuff
            e.IsInputKey = false;
        }
    }
