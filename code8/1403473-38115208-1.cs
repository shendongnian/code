	using System;
	using System.ComponentModel;
	namespace TestPropagationOfPropertyChanges
	{
		public class Model : NotifyPropertyChangedObject
		{
			#region Constructors
			public Model ()
			{
			}
			#endregion
			#region Private data members
			private string _first = string.Empty;
			private string _last = string.Empty;
			#endregion
			#region Public properties
			public string FirstName 
			{
				get
				{
					return _first;
				}
				set
				{
					_first = value;
					NotifyPropertyChanged ("FirstName");
				}
			}
			public string LastName
			{
				get
				{
					return _last;
				}
				set
				{
					_last = value;
					NotifyPropertyChanged ("LastName");
				}
			}
			#endregion
		}
	}	
