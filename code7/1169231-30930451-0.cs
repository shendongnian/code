    while ((str = reader.ReadLine()) != null)
    {
        contact.Items.Add(str);
        contact.Items.Add(reader.ReadLine());
        contact.Items.Add("");
    }
