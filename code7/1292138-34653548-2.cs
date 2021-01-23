   	public enum MyEnum
	{
		First,
		Second
	}
    public MyDisplayNameAttribute : DisplayNameAttribute
    {
        public MyDisplayNameAttribute (MyEnum en, string text1, string text2) : base (CorrectName (en, text1, text2))
        public static string CorrectName (MyEnum en, string text1, string text2)
        {
            return en == MyEnum.First ? text1 : text2;
        }
    } 
	public class LoginViewModel
	{
		const MyEnum En = MyEnum.First;
		
		[Required]
		[DataType(DataType.Password)]
		[MyDisplayName(MyEnum.Second, "password1", "password2")]
		public string Password { get; set; }
	}
