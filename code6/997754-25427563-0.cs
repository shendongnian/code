	public static double Max(this IEnumerable<double> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		double num = 0.0; // current max
		bool flag = false; // is first iteration
		foreach (double num2 in source)
		{
			if (flag)
			{
				if (num2 > num || double.IsNaN(num))
				{
					num = num2;
				}
			}
			else // initialization case
			{
				num = num2;
				flag = true;
			}
		}
		if (flag) // throw if there were no elements
		{
			return num;
		}
		throw Error.NoElements();
	}
