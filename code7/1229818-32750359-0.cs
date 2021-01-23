    public void AddCurrentInstance (List<StatsFile> listings)
    {
        if (listings == null)
        {
            Console.WriteLine("Received null listings. Returning...");
            return;
        }
        listings.Add(this.clone());
    }
