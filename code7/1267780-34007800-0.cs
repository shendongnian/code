    ...
    public bool RequireLocationName {
       get {
           return !Addresses.Any();
       }
    }
    
    [RequiredIf("RequireLocationName", true)]
    public bool LocationName { get; set; }
