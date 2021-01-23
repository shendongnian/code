    var matches = context.Customers.AsQueryable();
    if (!string.IsNullOrEmpty(txtLastName.Text))
    {
         matches = matches.Where(m => m.LastName == txtLastName.Text);
    }
    if (!string.IsNullOrEmpty(txtFirstName.Text))
    {
         matches = matches.Where(m => m.FirstName == txtFirstName.Text);
    }
    // repeat for searchable fields
    return matches.ToList();
