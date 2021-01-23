    using System;
	
	public class Program
	{
		class ClassA
		{
			public ClassB classB { get; set; }
		}
		
		class ClassB : ClassC
		{
		}
		
		class ClassC
		{
			public string message { get; set; }
		}
		
		static T FindClass<T>(object obj) where T : class
		{
			var classType = obj.GetType();
			var targetType = typeof(T);
			
			if (IsDerivedFrom(classType, targetType))
			{
				return (T)obj;
			}
			
			foreach (var prop in classType.GetProperties())
			{
				if ( prop.PropertyType.IsClass)
				{
					var childObj = prop.GetValue(obj);
					
					var target = FindClass<T>(childObj);
					if (target != null)
					{
						return target;
					}
				}
			}
			
			return null;
		}
		
		static bool IsDerivedFrom(Type class1, Type class2)
		{
			return class2.IsAssignableFrom(class1);
		}
		
		public static void Main()
		{
			var classA = new ClassA { classB = new ClassB() };
			classA.classB.message = "Hello";
			
			var classC = FindClass<ClassC>(classA);
			
			if (classC != null)
			{
				Console.WriteLine(classC.message);
			}
		}
	}
