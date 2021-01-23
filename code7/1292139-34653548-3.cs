   	public enum MyEnum
	{
		First,
		Second
	}
	public class LoginViewModel
	{
		const MyEnum En = MyEnum.First;
		
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = (En == MyEnum.First ? "Password" : "aaa"))]
		public string Password { get; set; }
	}
