    var allowedOptions = new ODataValidationSettings
            {
                AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Filter | AllowedQueryOptions.Skip |
                                      AllowedQueryOptions.OrderBy | AllowedQueryOptions.InlineCount
            };
    options.Validate(allowedOptions);
    var Data = options.ApplyTo(Store.Aerodromo.All(), new ODataQuerySettings()
        {
            PageSize = 10 // now you get a next page link when u say $top=20
        });
