	public class ExecutiveBranchSection : ConfigurationSection
	{
		public const string Tag = "executiveBranch";
		[ConfigurationProperty(PresidentCollection.Tag)]
		public PresidentCollection Presidents { get { return (PresidentCollection)base[PresidentCollection.Tag]; } }
	}
	[ConfigurationCollection(typeof(President),
		CollectionType = ConfigurationElementCollectionType.BasicMap,
		AddItemName = President.Tag)]
	public class PresidentCollection : ConfigurationElementCollection
	{
		public const string Tag = "presidents";
		protected override string ElementName { get { return President.Tag; } }
		public President this[int index]
		{
			get { return (President)base.BaseGet(index); }
			set
			{
				if (base.BaseGet(index) != null)
				{
					base.BaseRemoveAt(index);
				}
				base.BaseAdd(index, value);
			}
		}
		new public President this[string name] { get { return (President)base.BaseGet(name); } }
		protected override ConfigurationElement CreateNewElement()
		{
			return new President();
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as President).Key;
		}
	}
	public class President : ConfigurationElement
	{
		public const string Tag = "president";
		[ConfigurationProperty("key", IsRequired = true)]
		public string Key { get { return (string)base["key"]; } }
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name { get { return (string)base["name"]; } }
		[ConfigurationProperty("legacy", IsRequired = false)]
		public string Legacy { get { return (string)base["legacy"]; } }
	}
