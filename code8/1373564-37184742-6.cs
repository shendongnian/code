    public interface ITrnsitReport
    {
        List<UserDefinedType> GetTransitReportData ();
        ValidateType ValidateType { get; }
    }
    
    public enum ValidateType
    {
        PPDC = 1,
        PAI = 2
    }
