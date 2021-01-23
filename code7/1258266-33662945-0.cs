    public int GetHashCode(SomeType sometype)
	{
	 //Calculate the hash code for the SomeType.
	 return new { sometype.Application, sometype.ExternalID }.GetHashCode();
	}
