	public override bool Validate()
	{
	  foreach ( EdiElement elem in _elements )
	  {
		if ( !_checkElementIsValid( this, elem ) )
		  base.ValidationErrors.Add( string.Format( "Element {0} does not belong to segment {1}", this.GetType().Name, this.GetType().Name ) );
		else
		  elem.Validate(); // <-- I want this to call derived class method
	  }
	  return base.ValidationErrors.Count == 0;
	}
	
	public abstract class EdiElement : Edi
	{
	  public abstract override bool Validate();
	}
	public abstract class EdiDataElement<T> : EdiElement
	{
	  public T Value { get; set; }
	}
    /// <summary>
    ///  To specify a component of an address.
    /// </summary>
    [DataElementMetadata(
        Name = "Address component",
        Description = "To specify a component of an address.",
        Type = Types.Type.an,
        Length = "0..70" )]
    public class E3286 : EdiDataElement<String>
    {
        public override bool Validate()
        {
            base.ValidationErrors.Add( "Validation error!" );
            return false;
        }
    }
