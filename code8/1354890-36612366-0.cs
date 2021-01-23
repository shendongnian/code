    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string myString = textBox1.Text;
            bool found = false;
            listBox1.FindString("");
            for (int i = 0; i < listBox1.Items.Count - 1; i++)
            {
                if(listBox1.Items[i].ToString().Contains(myString))
                {
                    listBox1.SetSelected(i, true);
                    found = true;
                    break;
                }
            }                        
            if(!found)
            {
                MessageBox.Show("Item not found!");
            }                
        }
