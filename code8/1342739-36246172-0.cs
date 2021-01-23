    public class UnitTest8
	{
		[TestMethod]
		public void TestJson1()
		{
			var test = new OrderedDictionary<int, Rectangle>();
			test.Add(1, new Rectangle(0, 0, 50, 50));
			test.Add(42, new Rectangle(1, 1, 1, 1));
			string s = JsonConvert.SerializeObject(test);
			var deserialized = JsonConvert.DeserializeObject<OrderedDictionary<int, Rectangle>>(s);
			// This fails as expected
			object someRect = deserialized[1];
			Assert.IsNotNull(someRect);
			Assert.IsTrue(someRect is Rectangle);
		}
		[TestMethod]
		public void TestJson2()
		{
			var test = new SortedDictionary<int, Rectangle>();
			test.Add(1, new Rectangle(0, 0, 50, 50));
			test.Add(42, new Rectangle(1, 1, 1, 1));
			string s = JsonConvert.SerializeObject(test);
			var deserialized = JsonConvert.DeserializeObject<SortedDictionary<int, Rectangle>>(s);
			object someRect = deserialized[1];
			Assert.IsNotNull(someRect);
			Assert.IsTrue(someRect is Rectangle);
		}
		public class OrderedDictionary<TKey, TValue> : OrderedDictionary, IEnumerable<KeyValuePair<TKey, TValue>>
		{
			IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
			{
				foreach (TKey key in Keys)
				{
					yield return new KeyValuePair<TKey, TValue>(key, (TValue)this[key]);
				}
			}
		}
	}
