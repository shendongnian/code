    private bool wasAlreadyClickedOnce;
    private void uxCheckBoxMouseClick(object sender, MouseEventArgs e)
    {
        if (!wasAlreadyClickedOnce)
        {
            wasAlreadyClickedOnce = true;
            return;
        }
        if (uxMouseCopyCheckBox.Checked)
        {
            MessageBox.Show("Test");
            uxMouseCopyCheckBox.Checked = false;
        }
    }
