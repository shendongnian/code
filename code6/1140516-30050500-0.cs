    public class PatientData
    {
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime DateOfBirth{ get; set; }
        //Some Other Columns
    }
 
