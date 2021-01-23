    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
    ComboBox senderComboBox = (ComboBox) sender;
    int selectedValue = (int)senderComboBox.SelectedValue;
    // and assuming that there's nothing wrong with this code
    using (var context2 = new tvdm())
        {
            var cus = context2.tblContacts
                .Where(c => c.ClientID == selectedValue)
               .Select(c => new { c.LastName, c.FirstName, c.JobTitle, c.Telephone, c.Mobile, c.EMail })
                .OrderBy(p => p.LastName)
                .ToList();
            dataGridView1.DataSource = cus;
        }
}
