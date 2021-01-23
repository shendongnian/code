	public int CompareTo(RepeatedFactorial other)
	{
	  if (BaseNumber == 0)
	  {
		// If Repeats is zero the value of this is zero, otherwise
		// this is the same as a value with BaseNumber == 1 and no factorials.
		// So delegate to the handling of that case.
		if (Repeats == 0) return other.BaseNumber == 0 && other.Repeats == 0 ? 0 : -1;
		return new RepeatedFactorial(1, 0).CompareTo(other);
	  }
	  if (other.BaseNumber == 0)
		// Likewise
		return other.Repeats == 0 ? 1 : CompareTo(new RepeatedFactorial (1, 0));
	  if (Repeats == other.Repeats)
		// X < Y == X! < Y!. X > Y == X! > Y! And so on.
		return BaseNumber.CompareTo(other.BaseNumber);
	  if (Repeats > other.Repeats)
	    return -other.CompareTo(this);
	  if (Repeats != 0)
        return new RepeatedFactorial(BaseNumber, 0).CompareTo(new RepeatedFactorial(other.BaseNumber, other.Repeats - Repeats);
	  if (other.BaseNumber > 12)
	    return -1; // this is less than other
	  ???
	}
