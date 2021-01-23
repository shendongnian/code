    private void txtConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            // checks if the last key that was pressed was the enter key
            if (e.KeyChar == (char)Keys.Return)
            {
                // once the user presses enter write the date
                Console.WriteLine("");
            }
        }
