    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [NotMapped]
    [IgnoreDataMemberAttribute]
    public Hl7.Fhir.Model.RemittanceOutcome? Outcome
    {
        get { return OutcomeElement != null ? OutcomeElement.Value : null; }
        set
        {
            if(!value.HasValue)
              OutcomeElement = null; 
            else
              OutcomeElement = new Code<Hl7.Fhir.Model.RemittanceOutcome>(value);
            OnPropertyChanged("Outcome");
        }
    }
