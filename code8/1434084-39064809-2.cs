	public static class Foo
	{
		public static double GetAngle(double a, double expression)
		{
			if (expression < 0.0)
			{
				double result = a - Math.Sqrt(-expression);
				if (result > 0.0)
					return Math.PI * 0.5;
				else if (result < 0.0)
					return Math.PI * 1.5;
				else
					return 0.0;
			}
			else
				return Math.Atan2(a, -Math.Sqrt(expression));
		}
	}
