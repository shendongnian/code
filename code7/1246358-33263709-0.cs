    public abstract class DataFileParent
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
    
            public int MyDataField { get; set; }
            public string MyOtherDataField { get; set; }
        }
    
    public class DataFileEditor : DataFileParent
        {
        }
    
    public class DataFileStore : DataFileParent
        {
        }
