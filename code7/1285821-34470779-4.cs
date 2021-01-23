        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboKeyPressed();
        }
        private void comboKeyPressed()
        {
            if (comboBox1.Text == lastFilter)
            {
                return;
            }
            
            object[] originalList = (object[]) comboBox1.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[comboBox1.Items.Count];
                comboBox1.Items.CopyTo(originalList, 0);
                comboBox1.Tag = originalList;
            }
            // prepare list of matching items
            string s = comboBox1.Text.ToLower();
            IEnumerable<object> newList = originalList;
            if (s.Length > 0)
            {
                newList = originalList.Where(item => item.ToString().ToLower().Contains(s));
            }            
            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            comboBox1.Items.Clear();
            // re-set list
            comboBox1.Items.AddRange(newList.ToArray());
            comboBox1.Select(Text.Length -1, 0);
            lastFilter = comboBox1.Text;
            comboBox1.DroppedDown = true;
        }
