    private Color _originalColor = Color.LightGray;
    private Color _newColor = Color.LightSkyBlue;
    private bool _isOrigColor = true;
    Timer _tmrChangeColor;
    private void btnTest_Click(object sender, EventArgs e)
    {
        if (_tmrChangeColor != null) return;
        _tmrChangeColor = new Timer {Interval = 2000, Enabled = true};
        _tmrChangeColor.Tick += _tmrChangeColor_Tick;
    }
    
    void _tmrChangeColor_Tick(object sender, EventArgs e)
    {
        btnTest.BackColor = _isOrigColor ? _newColor : _originalColor;
        _isOrigColor = !_isOrigColor;
        _tmrChangeColor.Dispose();
        _tmrChangeColor = null;
    }
