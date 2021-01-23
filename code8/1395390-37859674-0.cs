        public void FillCheckBox(List<person> listan)
        {
            checkedListBox1.Items.Clear();
            foreach (person item in listan)
            {
                checkedListBox1.Items.Add(item, true);
            }
        }
