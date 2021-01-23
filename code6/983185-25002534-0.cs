    public IEnumerable<Supplier> Find(string name)
    {
        using (var suppre = new SupplierRepository())
        {
            return suppre
                .Where(x => x.Supplier_Name == name)
                .Select(x => AutoMapper.Mapper.Map<SupplierView>(x));
        }
    }
