    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class A
    {
    
    [FieldConverter(ConverterKind.Date, "M/dd/yyyy hh:mm:ss tt")]
    [FieldFixedLength(22)]
    private DateTime mAONE;
    
    public DateTime AONE
    {
       get { return mAONE; }
       set { mAONE = value; }
    }
