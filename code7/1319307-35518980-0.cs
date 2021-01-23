        private void chk(object sender, EventArgs e)
        {
            // Make a list of all checkboxes.
            var checkboxes = this.Controls.OfType<CheckBox>().ToList();
            // Count how many are checked.
            int numberChecked = checkboxes.Where(x => x.Checked).ToList().Count;
            foreach (var cb in checkboxes)
            {
                cb.Enabled = numberChecked < 2 || cb.Checked;
            }
        }
