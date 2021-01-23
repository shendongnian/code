    using System.Windows.Input;
    ...
    public Key CustomKey = Key.B;
    // or this if you really want to convert the string representation
    public Key CustomKey = (Key)Enum.Parse(typeof(Key), "B");
    private void activeArea_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == CustomKey)
        {
            MessageBox.Show("Key Pressed");
        }
    }
