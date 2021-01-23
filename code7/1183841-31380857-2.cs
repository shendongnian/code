		using System;
		namespace AddExample
		{
			class Program
			{
				static void Main(string[] args)
				{
					float result = Add(20, 20.3f);
					Console.WriteLine("Result: {0}", result);
					Console.ReadLine();
				}
				private static float Add(params object[] values)
				{
					float result = 0;
					foreach (var value in values)
					{
						if (value is int)
						{
							result += (int) value;
						}
						else if (value is float)
						{
							result += (float) value;
						}
						else
						{
							throw new NotSupportedException("Add does not support type");
						}
					}
					return result;
				}
			}
		}
