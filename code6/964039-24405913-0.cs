    internal class ConstantMatcher : IMatcher
	{
	    ...
		public bool Matches(object value)
		{
			if (object.Equals(constantValue, value))
			{
				return true;
			}
			if (this.constantValue is IEnumerable && value is IEnumerable)
			{
				return this.MatchesEnumerable(value);
			}
			return false;
		}
		private bool MatchesEnumerable(object value)
		{
			var constValues = (IEnumerable)constantValue;
			var values = (IEnumerable)value;
			return constValues.Cast<object>().SequenceEqual(values.Cast<object>());
		}
	}
