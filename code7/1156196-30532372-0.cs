    [Required]
	[MaxLength(12)]
	[MinLength(1)]
	[RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
	public string Uprn { get; set; }
