    private readonly ICollection<BusinessPartnerLanguage> _BusinessPartnerLanguage
        = new HashSet<BusinessPartnerLanguage>();
    public virtual ICollection<BusinessPartnerLanguage> BusinessPartnerLanguage
    {
        get { return _BusinessPartnerLanguage; }
    }
