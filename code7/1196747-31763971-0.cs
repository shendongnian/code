    public int AddContact(Contact contact)
    {
        return Convert.ToInt32(AWJE.Database.SqlQuery<int>
            ("usp_InsertContact @Name", contact.Name));
    }
