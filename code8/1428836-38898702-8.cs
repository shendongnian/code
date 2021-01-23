    [AttributeUsage( AttributeTargets.Property )]
	public class DepondsOnAttribute : Attribute
	{
		public DepondsOnAttribute( string name )
		{
			Name = name;
		}
		public string Name { get; }
	}
	public class PropertyChangedNotifier<T> : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public PropertyChangedNotifier( T owner )
		{
			mOwner = owner;
		}
		public void OnPropertyChanged( string propertyName )
		{
			var handler = PropertyChanged;
			if( handler != null ) handler( mOwner, new PropertyChangedEventArgs( propertyName ) );
			List<string> dependents;
			if( smPropertyDependencies.TryGetValue( propertyName, out dependents ) )
			{
				foreach( var dependent in dependents ) OnPropertyChanged( dependent );
			}
		}
		static PropertyChangedNotifier()
		{
			foreach( var property in typeof( T ).GetProperties() )
			{
				var dependsOn = property.GetCustomAttributes( true )
										.OfType<DepondsOnAttribute>()
										.Select( attribute => attribute.Name );
				foreach( var dependency in dependsOn )
				{
					List<string> list;
					if( !smPropertyDependencies.TryGetValue( dependency, out list ) )
					{
						list = new List<string>();
						smPropertyDependencies.Add( dependency, list );
					}
					if (property.Name == dependency)
						throw new ApplicationException(String.Format("Property {0} of {1} cannot depends of itself", dependency, typeof(T).ToString()));
					list.Add( property.Name );
				}
			}
		}
		private static readonly Dictionary<string, List<string>> smPropertyDependencies = new Dictionary<string, List<string>>();
		private readonly T mOwner;
	}
