    internal class RoomList
    {
	    public string Location { get; set; }
	    public string ClassNumber { get; set; }
	    public override string ToString()
        {
	        return Location + ", " + ClassNumber;
        } 
    }
