		public class YourDataType
		{
			public string Key;
			public string Value1;
			public string Value2;
			// add some various data here...
		}
		public class YourDataTypeCollection : List<YourDataType>
		{
			public YourDataType this[string key]
			{
				get
				{
					return this.FirstOrDefault(o => o.Key == key);
				}
				set
				{
					YourDataType old = this[key];
					if (old != null)
					{
						int index = this.IndexOf(old);
						this.RemoveAt(index);
						this.Insert(index, value);
					}
					else
					{
						this.Add(old);
					}
				}
			}
		}
