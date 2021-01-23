    [HttpGet]
    public List<Phone> GetPhones()
    {
        return new TestPhoneService().GetTestData();
    }
