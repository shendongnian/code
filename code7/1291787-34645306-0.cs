	public class QuestionCompare : IComparer<Question>
	{
		public int Compare(Question x, Question y)
		{
			string a = x.QuestionNumber;
			string b = y.QuestionNumber;
	
			var aDigits = new string(a.TakeWhile(c => char.IsDigit(c)).ToArray());
			var bDigits = new string(b.TakeWhile(c => char.IsDigit(c)).ToArray());
			int aInt = String.IsNullOrEmpty(aDigits) ? 0 : int.Parse(aDigits);
			int bInt = String.IsNullOrEmpty(bDigits) ? 0 : int.Parse(bDigits);
	
			return aInt != bInt ? aInt.CompareTo(bInt) : a.CompareTo(b);
		}
	}
