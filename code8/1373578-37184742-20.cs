    public TransitReport (IValidateInput[] inputValidation,
                            ITransitRepository transitRepo)
    {
        _inputValidation = inputValidation.FirstOrDefault(x => x.ValidateType == ValidateType.PPC);
        _transitRepo = transitRepo;
    }
