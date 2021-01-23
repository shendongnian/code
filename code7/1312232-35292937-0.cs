    var cus = context2.tblContacts
        .Where(c => c.ClientID == Convert.ToInt32(myComboBox.SelectedItem))
        .Select(c => new {c.LastName, c.FirstName, c.JobTitle, c.Telephone, c.Mobile, c.EMail })
        .OrderBy(p => p.LastName)
        .ToList();
