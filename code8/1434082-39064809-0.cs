	using System.Numerics;
	public static class Foo
	{
		public static double GetAngle(double a, double expression)
		{
			Complex cA = new Complex(0, a);
			Complex sqrt = Complex.Sqrt(expression);
			Complex result = cA - sqrt;
			return result.Phase;
		}
	}
