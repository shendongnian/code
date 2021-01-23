    public class PersonViewCell : ViewCell
    {
    	Image image;
    
    	public PersonViewCell()
    	{
    		image = new Image();
    	}
    
    	protected override void OnBindingContextChanged()
    	{
    		base.OnBindingContextChanged();
    
    		var person = BindingContext as Person;
    		image.Source = person.Gender == GenderType.Male ? "Male.png" : "Feale.png";
    	}
    }
