    private void watcher_keyDown(object sender, KeyEventArgs e)
    {
        Console.WriteLine("keyDown: " + e.KeyData.ToString());
    }
    private void watcher_KeyPress(object sender, KeyPressEventArgs e)
    {
        Console.WriteLine("keyPress: " + e.KeyChar.ToString());
    }
    public void watcher_KeyUp(object sender, KeyEventArgs e)
    {
        Console.WriteLine("keyUp: " + e.KeyData.ToString());
    }
    keyDown: RControlKey
    keyDown: A, Control
    keyPress: 
    keyUp: A, Control
    keyUp: RControlKey, Control
