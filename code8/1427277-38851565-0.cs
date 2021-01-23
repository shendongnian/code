    [RequiredIf("B == null", ErrorMessage = "Either A or B should be filled")]
    public string A { get; set; }
    
    [RequiredIf("A == null", ErrorMessage = "Either A or B should be filled")]
    public string B { get; set; }
