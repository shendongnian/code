    public MedicineMap()
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Date);
        HasManyToMany(x => x.Companies)
            .Cascade.All()
            .Inverse()
            .Table("MedicineCompany");
    }
