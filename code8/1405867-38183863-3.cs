    //Added
    private void Txtbx_KeyDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
    }
 
