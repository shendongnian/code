    using(var client = new VitalSignServiceClient()
    {
        _vitalSigns = client.GetAllVitalSignsWithValues().ToList();
    }
    public ICollection<VitalSign> GetAllVitalSigns()
    {
        using(ctx = new YourContext())
        {
           // do stuff
        }
    }
