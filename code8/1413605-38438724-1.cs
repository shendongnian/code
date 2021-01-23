    public void AddTagToContact(string tagName, string contactEmail)
    {
        SetTimer(() => TagContactByMail(contactEmail, tagName));
        aTimer.Dispose();
    }
