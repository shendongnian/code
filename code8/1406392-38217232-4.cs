    public class ErrorInfoEx : ErrorInfo
    {
       public new string Details { get; set; }
       public bool ShouldSerializeDetails() { return false; }
       public ErrorInfoEx(int code, string message) : base(code, message) { }
       public string MyField { get; set; }
    }
