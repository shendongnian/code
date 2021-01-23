        private static void ConfigAndTestFluent()
        {
            CustomerDto customer = new CustomerDto();
            Validator<CustomerDto> validator = new Validator<CustomerDto>(x=>x.Name!="Remarks"); //we specify here the matching filter for properties
            ValidationResult results = validator.Validate(customer);
        }
