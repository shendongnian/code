    [UIHint("ValuesModel")]
    public ValuesModel LowValue { get; set; }
    [UIHint("ValuesModel")]
    [AssertThat("HighValue > LowValue", ErrorMessage = "Insert your error message here")]
    public ValuesModel HighValue { get; set; }
