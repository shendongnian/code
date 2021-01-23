        bool _checkedManually = true;
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!_checkedManually)
            {
                _checkedManually = true;
                return;
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkBox1.Checked)
                    checkedListBox2.SetItemChecked(i, true);
                else
                    checkedListBox2.SetItemChecked(i, false);
            }
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _checkedManually = false;
            if (checkedListBox2.CheckedItems.Count == checkedListBox2.Items.Count)
                checkBox1.Checked = true;
            else if (checkedListBox2.CheckedItems.Count != checkedListBox2.Items.Count)
                checkBox1.Checked = false;
        }
