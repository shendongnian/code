    private void button16_Click(object sender, EventArgs e)
    {
        clearStuff((Control.ControlCollection)this.Controls);
    }
    
    public void clearStuff(Control.ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            if (c is Panel)
            {
                clearStuff(c);
            }
            else if (c is Checkbox)
            {
                c.Checked = false;
            }
        }
    }
