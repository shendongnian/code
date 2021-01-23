    public enum PhoneCode
    {
        [DescriptionAttribute("991")]
        Emergency,
        [DescriptionAttribute("411")]
        Info,
    }
    PhoneCode code;
    EnumsNET.Enums.TryParse("991", out code, EnumsNET.EnumFormat.Description)
