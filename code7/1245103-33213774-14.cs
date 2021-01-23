    public void UserMapper  : IEntityMapper
    {
        private AddressMapper _childMapper = new AddressMapper();
        public void Map(IDataRecord record)
        {
            var user = new User();
            user.FirstName = record["FirstName"]
            user.Address = _childMapper.Map(record, "Address_");
        }
    }
