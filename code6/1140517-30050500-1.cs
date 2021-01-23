    public class PatientData
    {
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DateOfBirth{ get; set; }
        //Some Other Columns
    }
 
