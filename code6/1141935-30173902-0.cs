    public void DoStuff(DataGridView dgv)
    {
        if (dgv.ReadOnly)
        {
            dgv.ReadOnly = false;
            // Do related stuff.
        }
        else
        {
            dgv.ReadOnly = true;
            // Do other related stuff.
        }
    
        // Do common stuff.
    }
