    private void Form1_Move(object sender, EventArgs e)
    {
       // you may or may not need this flag
       // you would set and clear in the form's constructor and at the end of the Load event.
        if (loading) return; 
        placeForm2();
    }
    private void Form1_Resize(object sender, EventArgs e)
    {
        placeForm2();
    }
    public void placeForm2()
    {
        form2.Top = this.Top;
        form2.Left = this.Left + this.Width;
        int sw = Screen.FromControl(this).WorkingArea.Width;
        int sh = Screen.FromControl(this).WorkingArea.Height;
        if (form2.Right >= sw) form2.Left = this.Left - form2.Width;
        if (form2.Bottom >= sh) form2.Top = sh - form2.Height;
    }
