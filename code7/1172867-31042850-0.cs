        private void submitButton_Click(object sender, EventArgs e)
        {
            List<string> checkedItems=(from Control c in Controls where c is CheckBox && ((CheckBox)c).Checked select c.Text).ToList();
            MessageBox.Show(string.Join(";", checkedItems));
        }
