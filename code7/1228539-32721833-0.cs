    public CustomerClient : BaseClient
    {
        public override BaseDTO GetData()
        {
            // CustomerDTO : BaseDTO
            return new CustomerDTO(this.CustomerNameTextbox);
        }
    }
