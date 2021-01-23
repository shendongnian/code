       private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
           label1.Text = null == listBox1.SelectedItem 
             ? ""
             : "Your Selected: " + listBox1.SelectedItem.ToString();
       }
    
       private void button2_Click(object sender, EventArgs e) {
         // Looks redundant, listBox1_SelectedIndexChanged will do 
         //label1.Text = "";    
     
         // Deselect item, but not remove it
         if (listBox1.SelectedIndex >= 0)
           listBox1.SelectedIndex = -1;
         // In case you want to remove the item (not deselect) - comment out the code below
         // if (listBox1.SelectedIndex >= 0)
         //   listBox1.Items.RemoveAt(listBox1.SelectedIndex);
       }
