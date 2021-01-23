	public class MyValueProvider : BindingSourceValueProvider, IValueProvider
	{
		private IEnumerable<KeyValuePair<string, string>> _keyMap;
		private readonly CultureInfo _culture;
		private PrefixContainer _prefixContainer;
		private IFormCollection _values;
		public MyValueProvider(BindingSource form, IFormCollection values, CultureInfo culture) : this(form, values, null, culture) { }
		public MyValueProvider(BindingSource form, IFormCollection values, IEnumerable<KeyValuePair<string, string>> keyMap, CultureInfo culture) : base(form)
		{
			if (form == null)
			{
				throw new ArgumentNullException(nameof(form));
			}
			if (values == null)
			{
				throw new ArgumentNullException(nameof(values));
			}
			_values = values;
			_culture = culture;
			_keyMap = keyMap;
		}
		public CultureInfo Culture
		{
			get { return _culture; }
		}
		protected PrefixContainer PrefixContainer
		{
			get
			{
				if (_prefixContainer == null)
				{
					_prefixContainer = new PrefixContainer(_values.Keys);
				}
				return _prefixContainer;
			}
		}
		public override bool ContainsPrefix(string prefix)
		{
			return PrefixContainer.ContainsPrefix(prefix);
		}
		public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
		{
			if (prefix == null)
			{
				throw new ArgumentNullException(nameof(prefix));
			}
			return PrefixContainer.GetKeysFromPrefix(prefix);
		}
		public override ValueProviderResult GetValue(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			var pair = _keyMap.FirstOrDefault(map => map.Key.EndsWith(key));
			if (pair.Value == null)
			{
				return ValueProviderResult.None;
			}
			var values = _values[pair.Value];
			if (values.Count == 0)
			{
				return ValueProviderResult.None;
			}
			return new ValueProviderResult(values, Culture);
		}
	}
