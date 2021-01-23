    private void FormClosing(object sender, FormClosingEventArgs e)
    {
        CachedText = scintilla.Text;
    }
    
    public string CachedText { get; private set; }
