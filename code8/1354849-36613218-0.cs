    public IEnumerable<Client> GetClients()
    {
        List<Client> clients = (from c in this.repository.Clients select c).ToList();
        return clients.AsEnumerable();
    }
