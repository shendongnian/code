        private void cboxcos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int value = (int)comboBox1.SelectedValue;
            using (var context2 = new tvdm())
            {
                var cus = context2.tblContacts
                    .Where(c => c.ClientID == value)
                   .Select(c => new { c.LastName, c.FirstName, c.JobTitle, c.Telephone, c.Mobile, c.EMail })
                    .OrderBy(p => p.LastName)
                    .ToList();
                dataGridView1.DataSource = cus;
            }
        }
