    private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            }
    
     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                string itemText = comboBox1.GetItemText(comboBox1.SelectedItem);
    
                if ((itemText == "Admins") || (itemText == "Users"))            
                    comboBox1.SelectedIndex = -1;
            }
    
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                string itemText = comboBox1.GetItemText(comboBox1.Items[e.Index]);
    
                if ((itemText == "Admins") || (itemText == "Users"))
                {
                    using (var f = new Font("Microsoft Sans Serif", 8, FontStyle.Bold))
                        e.Graphics.DrawString(itemText, f, Brushes.Black, e.Bounds);
                }
                else
                {
                    e.DrawBackground();
    
                    using (var f = new Font("Microsoft Sans Serif", 8, FontStyle.Regular))
                        e.Graphics.DrawString(itemText, f, Brushes.Black, e.Bounds);
    
                    e.DrawFocusRectangle();
                }
            }
