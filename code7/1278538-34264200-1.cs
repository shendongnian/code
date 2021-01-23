    private void ChangeCursor(Control control)
    {
        foreach (Control con in control.Controls)
        {
            con.MouseHover += con_MouseHover;
            ChangeCursor(con);
        }
    }
    
    void con_MouseHover(object sender, EventArgs e)
    {
        Control ct = (Control) sender;
        ct.Cursor = Cursors.Hand;
    }
