    public class UniqueElementsRequiredAttribute : ValidationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the UniqueElementsRequiredAttribute class.
		/// </summary>
		/// <param name="typeOfCollectionElements">Type of the elements in the collection. Leave as null if testing the elements directly rather than one of their properties.</param>
		/// <param name="nameOfPropertyToTestForUniqueness">Name of element property desired to be unique. Leave as null if testing the elements directly rather than one of their properties. MUST BE EXACT.</param>
		public UniqueElementsRequiredAttribute(Type typeOfCollectionElements = null, string nameOfPropertyToTestForUniqueness = null)
		{
			NameOfPropertyToTestForUniqueness = nameOfPropertyToTestForUniqueness;
			TypeOfCollectionElements = typeOfCollectionElements;
		}
		private string NameOfPropertyToTestForUniqueness { get; set; }
		private Type TypeOfCollectionElements { get; set; }
		public override bool IsValid(object value)
		{
			var collection = value as IEnumerable;
			if (collection == null)
			{
				return true;
			}
			var listToTestForUniqueness = CreateListToTestForUniqueness(collection);
			int countOfAllElements = listToTestForUniqueness.Count();
			int countOfDistinctElements = listToTestForUniqueness.Distinct().Count();
			return countOfAllElements == countOfDistinctElements;
		}
		private List<object> CreateListToTestForUniqueness(IEnumerable collection)
		{
			var listToTestForUniqueness = new List<object>();
			if (NameOfPropertyToTestForUniqueness != null && TypeOfCollectionElements != null)
			{
    // Trick 1
				PropertyInfo propertyInfoOfPropertyToTestForUniqueness = TypeOfCollectionElements.GetProperty(NameOfPropertyToTestForUniqueness);
				foreach (var element in collection)
				{
    // Trick 2
					listToTestForUniqueness.Add(propertyInfoOfPropertyToTestForUniqueness.GetValue(element));
				}
			}
			else
			{
				listToTestForUniqueness = collection.Cast<object>().ToList();
			}
			return listToTestForUniqueness;
		}
	}
