    private bool _isInsideTextChanged = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (_isInsideTextChanged) return; // return if was inside TextChanged.
        _isInsideTextChanged = true; // inside TextChanged
        // Do stuff...
        _isInsideTextChanged = false; // outside TextChanged
    }
