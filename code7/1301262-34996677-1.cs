    DateTime _lastKeystroke = new DateTime(0);
    string _barcode = string.Empty;
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            processKey((char) keyData);  // we need the Enter key
    //--- UPDATE: the key is processed - return "true", not false!
            return true;                 // do not steal it!
        }
        processKey((char)keyData);       // process other keys
        return base.ProcessCmdKey(ref msg, keyData);
    }
    void processKey(Keys key)
    {
        // check timing (>7 keystrokes within 50 ms)
        TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
        if (elapsed.TotalMilliseconds > 50)
        {
            _barcode = string.Emtpy;
        }
        // record keystroke & timestamp
        _barcode += (char)key;
        _lastKeystroke = DateTime.Now;
        // process barcode
        // --- barcode length should be > 1, not 0 (as the return char
        // itself was added above)
        if (key == Keys.Enter && _barcode.Length > 1)
        {
            string msg = new String(_barcode.ToArray());
            MessageBox.Show(msg);
            _barcode = string.Empty;
        }
    }
