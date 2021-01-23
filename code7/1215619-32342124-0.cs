    void HandleKeyPress(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            string input = (sender as TextBox)?.Text;
            //Your logic
            e.IsInputKey = true; //Don't do standard "Enter" things
        }
    }
