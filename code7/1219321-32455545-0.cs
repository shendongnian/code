	[DelimitedRecord(";")]
	[IgnoreEmptyLines]
	public class TestRecord
	{
	    //Mandatory
	    [FieldNotEmpty, FieldOrder(0), FieldTitle("A")]
	    public string A;
	    [FieldOptional, FieldOrder(1), FieldTitle("B")]
	    public string B;
	    [FieldOptional, FieldOrder(2), FieldTitle("C")]
	    public string C;
	}
