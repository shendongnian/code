		public class Poco
		{
			public string Name { get; set; }
			public double D { get; set; }
		}
		private static IEnumerable<Poco> Merge(IEnumerable<Poco> list1, IEnumerable<Poco> list2)
		{
			Dictionary<string, Poco> dict1 = list1.ToDictionary(l => l.Name, l => l);
			foreach (Poco p in list2)
			{
				if (dict1.ContainsKey(p.Name))
				{
					Poco result = dict1[p.Name];
					result.D += p.D;
					yield return result;
                    continue;
				}
				
				yield return p;
			}
		}
