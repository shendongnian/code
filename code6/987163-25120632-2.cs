    private void pictureBox2_Click(object sender, EventArgs e)
    {
        for (int i = listBox2.SelectedItems.Count - 1 ; i >= 0 ; i--)
        {
            // Get only the controls of type Label with Text property equal to the current item
            var labels = table2.Controls
                         .OfType<Label>()
                         .Where (c => c.Text == listBox2.SelectedItem.ToString())
                         .ToList();
           if(labels != null)  
           {
              for(int x = labels.Count()-1; x >= 0; x--)
                 table2.Remove(labels[x]);
           }
               
           // Get only the controls of type TextBox with Name property containing the current item
           var boxes = table2.Controls
                              .OfType<TextBox>()
                              .Where (c => c.Name.Contains(listBox2.SelectedItem.ToString())
                              .ToList();
           if(boxes != null)  
           {
              for(int x = boxes.Count()-1; x >= 0; x--)
                 table2.Remove(boxes[x]);
           }
           listBox2.Items.Remove(listBox2.SelectedItems[i]); 
        }
    }
 
