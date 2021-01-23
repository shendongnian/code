    private bool isCtrlHPressed;
    private void txt_callerName_KeyDown(object sender, KeyEventArgs e)
    {
        if (isCtrlHPressed && e.KeyCode == Keys.T && e.Modifiers == Keys.Control)
            Console.WriteLine("^");
        isCtrlHPressed = (e.KeyCode == Keys.H && e.Modifiers == Keys.Control);
    }
