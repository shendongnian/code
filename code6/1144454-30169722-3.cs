    public bool CanClose { private get; set; }
    private void frm_Protection_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !CanClose;
    }
