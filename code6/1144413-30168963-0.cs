	using System;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				decimal value = 123456.789M;
				Console.WriteLine(ConvertOrMinMax<Byte>(value));
				Console.WriteLine(ConvertOrMinMax<Int16>(value));
				Console.WriteLine(ConvertOrMinMax<Int32>(value));
				Console.WriteLine(ConvertOrMinMax<Int64>(value));
				Console.WriteLine(ConvertOrMinMax<Decimal>(value));
				Console.WriteLine(ConvertOrMinMax<Double>(value));
				Console.WriteLine(ConvertOrMinMax<float>(value));
				Console.Read();
			}
			static T ConvertOrMinMax<T>(decimal v)
			{
				var myType = typeof(T);
				if(myType == typeof(double) || myType == typeof(float))
					return (T)Convert.ChangeType(v, myType);
				decimal min = (decimal)Convert.ChangeType(myType.GetField("MinValue").GetValue(null), typeof(decimal));
				if (v < min)
					return (T)Convert.ChangeType(min, myType);
				decimal max = (decimal)Convert.ChangeType(myType.GetField("MaxValue").GetValue(null), typeof(decimal)); ;
				if (v > max)
					return (T)Convert.ChangeType(max, myType);
				return (T)Convert.ChangeType(v, myType);
			}
		}
	}
