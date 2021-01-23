    public List<Parent_Company> GetParentCompany(params int[] clientIds)
    {
        IEnumerable<Companie> ccs;
        if (clientIds.Length == 0)
            ccs = _xciRepository.GetAll<Companie>();
        else if (clientIds.Length == 1)
        {
            var clientId = clientIds[0];
            ccs = _xciRepository.Find<Companie>(x => x.CustCompID == clientId]);
        }
        else
            ccs = _xciRepository.Find<Companie>(x => clientIds.Contains(x.CustCompID));
        //-- more codes here
    }
