    public class BaseViewModel 
    {
		public Type Prop {get; set;}
		public Type Prop2 {get; set;}
		...etc...
    }
	
	public class SpecificViewModel : BaseViewModel
	{
		SpecificViewModel(Type Prop, Type Prop2) : base(Prop, Prop2, ...etc...) { }
		public Type specificProp {get; set;}
		...etc...
	}
