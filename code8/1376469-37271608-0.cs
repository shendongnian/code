	public class ByLengthAndAlphabeticallyOrderComparer : IComparer
	{
		int IComparer.Compare(Object x, Object y)
		{
			var stringX = x as string;
			var stringY = y as string;
			
			int lengthDiff = stringX.Length - stringY.Length;			
			if (lengthDiff !=)
			{
				return lengthDiff < 0 ? -1 : 1; // maybe the other way around -> untested ;)
			}
			
			return stringX.Compare(stringY);
		}
	}
