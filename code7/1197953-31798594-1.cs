    [Required]
    [Editable(true)]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Audit Result Global Ids")]
    [RegularExpressionOnListElements(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", ErrorMessage = "Audit Result Global Ids must be a list of one or more valid GUIDs.")]
    public List<Guid> AuditResultGlobalIds { get; set; }
