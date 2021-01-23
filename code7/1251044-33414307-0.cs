    // ..
    static void Main()
		{
			var request = GetDataRequest();
			//Get propertyValues for properties that are enumerable (i.e. lists,arrays etc)
			var collectionProperties = request.GetType()
											  .GetProperties(BindingFlags.Instance | BindingFlags.Public)
											  .Where(propertInfo => propertInfo.PropertyType.GetInterfaces().Any(x => x == typeof(IEnumerable)))
											  .Select(p => p.GetValue(request))
											  .Cast<IEnumerable<object>>().ToList();
			var totalCountForAllCollections = 0;
			// iterate through the list of propertyValues
			foreach (var collectionPropertyValue in collectionProperties)
			{
				totalCountForAllCollections += collectionPropertyValue.Count();
				collectionPropertyValue.DoSomething();
			}
			System.Console.WriteLine("The total count for all collections is : {0}", totalCountForAllCollections);
			System.Console.WriteLine("press any key to exit");
			System.Console.ReadLine();
		}
		public static void DoSomething<T>(this IEnumerable<T> objectCollection)
		{
			//etc...
			// N.B. you will have to use typeof(T) to implement logic specific to the type
			// If the logic in this method is non-specific to the typeof(T) then Implement logic accordingly
			System.Console.WriteLine("The type of the collection is: {0}", objectCollection.GetType());
			System.Console.WriteLine("The count of items in this collection is:{0}", objectCollection.Count());
		}
    // ..
