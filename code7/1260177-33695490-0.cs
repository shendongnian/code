	public class MyModel
	{
	    [DataType(DataType.Date)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
	    public DateTime? Date { get; set; }
	    [DataType(DataType.Time)]
	    public DateTime? TimeFrom { get; set; }
	    [DataType(DataType.Time)]
	    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
	    public DateTime? TimeUntil { get; set; }
	    [DataType(DataType.DateTime)]
	    public DateTime? SomeDate { get; set; }
	}
