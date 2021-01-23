	public class MyBaseClassBuilder
	{
		public SomeEnum EnumValue { get; set; }
		public User User { get; set; }
	}
	public static class MyBaseClassBuilderExtensions
	{
		public static T SetEnumValue<T>(this T instance, SomeEnum value)
			where T : MyBaseClassBuilder
		{
			instance.EnumValue = value;
			return instance;
		}
		public static T SetEnumValue<T>(this T instance, string value)
			where T : MyBaseClassBuilder
		{
			instance.EnumValue = (SomeEnum)Enum.Parse(typeof(SomeEnum), value);
			return instance;
		}
		public static T SetUser<T>(this T instance, User value)
			where T : MyBaseClassBuilder
		{
			instance.User = value;
			return instance;
		}
		public static T SetUser<T>(this T instance, string value)
			where T : MyBaseClassBuilder
		{
			instance.User = new User(value);
			return instance;
		}
		public static MyBaseClass Build(this MyBaseClassBuilder instance)
		{
			return new MyBaseClass(instance.EnumValue, instance.User);
		}
	}
