    string[] fields = context.Request.QueryString["Fields"].Split(',');
    string[] properties = typeof(Contacts).GetProperties().Select(r => r.Name).ToArray();
    fields = properties.Where(r => !fields.Contains(r)).ToArray();
    foreach (string field in fields)
	{
	    foreach (Contacts item in contactsArray)
        {
            item.GetType().GetProperty(field).SetValue(item, null)
        }
    }
