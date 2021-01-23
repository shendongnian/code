    TextBox editTB = null;   // a class level variable to hold the reference
    // here we get the reference to the editing control
    // other control types will work as well..
    private void dataGridView1_EditingControlShowing(object sender, 
                               DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is TextBox) 
        {
            editTB = (TextBox)e.Control;
            editTB.KeyPress -= editTB_KeyPress;
            editTB.KeyPress += editTB_KeyPress;
        }
    }
    void editTB_KeyPress(object sender, KeyPressEventArgs e)
    {
        // use the checks you actually need..
        if (e.KeyChar == '#')
        {
            // do your things..
            Console.WriteLine("---->" + e.KeyChar);
            e.Handled = true;
        }            
    }
