    public NPortfolio(int nr, string id, Dictionary<string, double> pos)
    {
        p_nr = nr;
        p_id = id;
        positions = new Dictionary<string, double>(pos);
    }
