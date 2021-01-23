    if (MessageBox.Show("Error message:\n" + ex.Message, "Unable to connect to database!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
    {
         Application.Exit();
    }
