    try {
        // You can test for the Caps Lock, Num Lock, or Scroll Lock key
        // by changing the value of Keys.
        Control.IsKeyLocked(Keys.CapsLock);
        MessageBox.Show("The Caps Lock key is ON.");
    }
    catch (System.Exception exp) {
        MessageBox.Show("The Caps Lock key is OFF.");
    }
