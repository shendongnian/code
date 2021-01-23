    [HttpGet]
    public List<Client> Get()
    {
        private ClientDBEntities db = new ClientDBEntities();
        retutn db.Client.ToList();
    }
