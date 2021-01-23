    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            // We can ask the user if they want to log out,
            // and if not, we can cancel the closing of the form.
            e.Cancel = true;
        }
        else
        {
            // System is closing form, automatically log out
            // and allow the form to close.
        }
    }
