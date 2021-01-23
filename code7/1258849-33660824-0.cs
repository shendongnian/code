    for (int i = contactFolder.Items.Count; i >= 1; i--)
    {
        Outlook.ContactItem ci = contactFolder.Items[i];
        objPropertyCLS = ci.UserProperties.Find(uPropertyCLS, Outlook.OlUserPropertyType.olNumber);
        if (objPropertyCLS == null)
        {
            Debug.Print("propCLS is null!");
        }
        else
        {
            ci.Delete();
        }         
    }
