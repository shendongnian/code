    private void pictureBox2_Click(object sender, EventArgs e)
    {
        for (int i = listBox2.SelectedItems.Count - 1 ; i >= 0 ; i--)
        {
            var lbl = table2.Controls
                      .OfType<Label>()
                      .FirstOrDefault (c => c.Text == listBox2.SelectedItem.ToString())
           if(lbl != null)  
               table2.Controls.Remove(lbl);
           var txt = table2.Controls
                           .OfType<TextBox>()
                           .FirstOrDefault (c => c.Name.Contains(listBox2.SelectedItem.ToString());
           if(txt != null) 
               table2.Controls.Remove(txt);
           listBox2.Items.Remove(listBox2.SelectedItems[i]); 
        }
    }
 
