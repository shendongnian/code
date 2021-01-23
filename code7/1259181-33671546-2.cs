	public class MyDerivedClassBuilder : MyBaseClassBuilder
	{
		public CustomClass CustomStuff { get; set; }
	}
	public static class MyDerivedClassBuilderExtensions
	{
		public static T SetCustomStuff<T>(this T instance, CustomClass value)
			where T : MyDerivedClassBuilder
		{
			instance.CustomStuff = value;
			return instance;
		}
		public static T SetCustomStuff<T>(this T instance, string value)
			where T : MyDerivedClassBuilder
		{
			instance.CustomStuff = new CustomClass(value);
			return instance;
		}
		public static MyDerivedClass Build(this MyDerivedClassBuilder instance)
		{
			return new MyDerivedClass(instance.EnumValue, instance.User, instance.CustomStuff);
		}
	}
