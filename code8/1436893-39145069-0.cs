    public RequiredFieldValidator(IStringLocalizer localizationService, string resourceID)
        {
            resourcekey = resourceID;
            localization = localizationService;
        }
    
    public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
    
            // Here I want to get localized message using SQL.
            var errorMessage = lozalization["requiredFieldMessage"];
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data- val-Required",errorMessage);
    
    }
