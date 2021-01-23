	public class ListWithWeight<T>
	{
		private readonly List<T> List = new List<T>();
		private readonly List<double> CumulativeWeights = new List<double>();
		private readonly Func<int, double> WeightForNthElement;
		private readonly Random Rnd = new Random();
		public ListWithWeight(Func<int, double> weightForNthElement)
		{
			WeightForNthElement = weightForNthElement;
		}
		public void Add(T element)
		{
			List.Add(element);
			double weight = WeightForNthElement(List.Count);
			if (CumulativeWeights.Count == 0)
			{
				CumulativeWeights.Add(weight);
			}
			else
			{
				CumulativeWeights.Add(CumulativeWeights[CumulativeWeights.Count - 1] + weight);
			}
		}
		public void Insert(int index, T element)
		{
			List.Insert(index, element);
			double weight = WeightForNthElement(List.Count);
			if (CumulativeWeights.Count == 0)
			{
				CumulativeWeights.Add(weight);
			}
			else
			{
				CumulativeWeights.Add(CumulativeWeights[CumulativeWeights.Count - 1] + weight);
			}
		}
		public void RemoveAt(int index)
		{
			List.RemoveAt(index);
			CumulativeWeights.RemoveAt(List.Count);
		}
		public T this[int index]
		{
			get
			{
				return List[index];
			}
			set
			{
				List[index] = value;
			}
		}
		public int Count
		{
			get
			{
				return List.Count;
			}
		}
		public int RandomWeightedIndex()
		{
			if (List.Count < 2)
			{
				return List.Count - 1;
			}
			double totalWeight = CumulativeWeights[CumulativeWeights.Count - 1];
			double selectedWeight = (Rnd.NextDouble() * (totalWeight - 1.0)) + 1;
			int ix = CumulativeWeights.BinarySearch(selectedWeight);
			// If value is not found and value is less than one or more 
			// elements in array, a negative number which is the bitwise 
			// complement of the index of the first element that is 
			// larger than value.
			if (ix < 0)
			{
				ix = ~ix;
			}
			// We want to use "reversed" weight, where first items
			// weight more:
			ix = List.Count - ix - 1;
			return ix;
		}
	}
