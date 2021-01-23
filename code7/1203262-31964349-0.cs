	public class CategoryResult : IComparable<CategoryResult>
	{
		public Category Category { get; set; }
		public int Score { get; set; }
		
		public int CompareTo(CategoryResult other)
		{
			int comparison = 0;
			if (this.Score == other.Score)
			{
				comparison = 0;
			}
			else if (this.Score > other.Score)
			{
				comparison = 1;
			}
			else if (this.Score < other.Score)
			{
				comparison = -1;
			}
			return comparison;
		}
	}
	
