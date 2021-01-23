	private int toInches(string input)
	{
		if (input.Contains("."))
		{
			string sfeet = input.Split('.')[0];
			string sinches = input.Split('.')[1];
			int feet, inches;
			if (int.TryParse(sfeet, out feet) && int.TryParse(sinches, out inches))
			{
				return feet*12 + inches;
			}
		    throw new Exception("The input is invalid");
		}
		else
		{
			int output;
			if (int.TryParse(input, out output))
			{
				return output*12;
			}
			throw new Exception("The input is invalid");
		}
	}
