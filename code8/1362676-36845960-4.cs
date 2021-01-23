        public void PopulateListBox(IEnumerable<CheckBox> checkboxes)
        {
            foreach(var item in checkboxes.Where((cb) => cb.Checked))
            {
                listBox1.Items.Add(item.Text);
            }
        }
