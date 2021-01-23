	public class MinFloatKeyValuePairList : Collection<KeyValuePair<int, float>>
	{
		private float _lowest = float.MaxValue;
		protected override void InsertItem(int index, KeyValuePair<int, float> item)
		{
			if (item.Value <= _lowest || this.Count == 0)
			{
				_lowest = item.Value;
				base.InsertItem(index, item);
			}
		}
	}
