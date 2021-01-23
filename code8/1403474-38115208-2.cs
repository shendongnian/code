	using System;
	namespace TestPropagationOfPropertyChanges
	{
		public class ViewModel : NotifyPropertyChangedObject
		{
			#region Private data members
			//This is public for testing purposes
			public Model _model = new Model();
			#endregion
			#region Constructors
			public ViewModel ()
			{
				_model.PropertyChanged += ReactToModelPropertyChanged;
			}
			#endregion
			#region Properties
			[ListenForModelPropertyChangedAttribute(new string [] {"FirstName", "LastName"})]
			public string FullName 
			{
				get
				{
					return _model.FirstName + _model.LastName;
				}
			}
