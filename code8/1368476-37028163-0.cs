    // your API action
    public IQueryable<ExampleDataDTO> Get(ODataQueryOptions opts)
    {
        // here is some odata settings to validate query params.
        var settings = new ODataValidationSettings()
        {
            // Initialize settings as needed.
            AllowedFunctions = AllowedFunctions.AllMathFunctions
        };
        
        // validating parameters
        opts.Validate(settings);
    
        var yourExampleQuery = // some data from db
       
        // apply all parameters that came within query to your data
        IQueryable results = opts.ApplyTo(yourExampleQuery.AsQueryable());
    
        // and return this
        return results as IQueryable<Product>;
    }
