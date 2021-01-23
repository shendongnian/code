    if (!d.Tables.Any(t => t.username.Equals(txtUserName.Text)))
    {
       d.Tables.InsertOnSubmit(c);
       d.SubmitChanges();
    }
