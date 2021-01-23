	public interface IConfigurationElementCollection<TParentedConfig, TParent> 
		where TParentedConfig : ParentedConfigElement<TParent>
		where TParent : class
	{
		TParent ParentElement { get; }
	}
	
	public class ConfigurationElementCollection<TElement, TParent> : IConfigurationElementCollection<ParentedConfigElement<TParent>, TParent>
		where TElement : ParentedConfigElement<TParent>, new() 
		where TParent : class
	{
		public TParent ParentElement { get; set; }
	
		protected ConfigurationElement CreateNewElement()
		{
			//**************************************************
			//COMPILER NO LONGER GIVES TYPE CONVERSION ERROR 
            //BECAUSE this IMPLEMENTS THE EXPECTED INTERFACE!
			//**************************************************
			return new TElement { ParentCollection = this };
		}
	}
	
	public class ParentedConfigElement<TParent> : ConfigurationElement where TParent : class
	{
		internal IConfigurationElementCollection<ParentedConfigElement<TParent>, TParent> 
			ParentCollection { get; set; }
	
		protected TParent Parent
		{
			get
			{
				return ParentCollection != null ? ParentCollection.ParentElement : null;
			}
		}
	}
