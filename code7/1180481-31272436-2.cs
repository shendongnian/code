    //INSTANT C# NOTE: C# does not support parameterized properties - the following property has been rewritten as a 'set' method:
    //ORIGINAL LINE: Public WriteOnly Property Text(ByVal index As Integer) As String
    	public void set_Text(int index, string value)
    	{
    	    lblTemp[index].Text = value;
    	}
