    	public class SimpleMathVM
	{
		[Required(ErrorMessage = "Please enter valid numbers before selecting an operation.")]
		[Display(Name = "First number")]
		public float Num1 { get; set; }
		[Required(ErrorMessage = "Please enter valid numbers before selecting an operation.")]
		[Display(Name = "Second number")]
		public float Num2 { get; set; }
		public string Result { get; set; }
		public char Operation { get; set; }
	}
