    // Stores the keys in pressed state.
    private HashSet<Keys> _pressedKeys = new HashSet<Keys>();
    // Used in DisplayKeys method.
    private StringBuilder _sb = new StringBuilder();
    // Form constructor
    public frmKeyboard()
    {
        InitializeComponent();
        KeyPreview = true; // Activate key preview at form level.
    }
    private void frmKeyboard_KeyDown(object sender, KeyEventArgs e)
    {
        // Each time a key is pressed, add it to the set of pressed keys.
        _pressedKeys.Add(e.KeyCode);
        DisplayKeys();
    }
    private void frmKeyboard_KeyUp(object sender, KeyEventArgs e)
    {
        // Each time a key is released, remove it from the set of pressed keys.
        _pressedKeys.Remove(e.KeyCode);
        DisplayKeys();
    }
    private void DisplayKeys()
    {
        _sb.Clear();
        foreach (Keys key in _pressedKeys.OrderBy(k => k)) {
            _sb.AppendLine(key.ToString());
        }
        label1.Text = _sb.ToString();
    }
