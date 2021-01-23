    listViewClients.Items.Clear();
    
    for (int a = 0; a < clients.Count; a++)
    {
        listViewClients.Items.Add(new Clients
        {
            isChecked = false,
            salutation = clients[a].salutation,
            title = clients[a].title,
            first_name = clients[a].first_name,
            last_name = clients[a].last_name,
            commercialunitnumber = clients[a].commercialunitnumber,
        });
    }
