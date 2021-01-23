    if (e.KeyCode == Keys.Down)
    {
       if(combo.SelectedIndex+1 <= combo.Items.Count)
        {
           combo.SelectedIndex++
        }
       else
        {
         //show warning here;
        }
    }
