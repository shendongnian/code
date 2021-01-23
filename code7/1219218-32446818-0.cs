	public class YourViewModel : ViewModelBase
	{
		private string _FirstProperty = "";
		public string FirstProperty
		{
			get { return this._FirstProperty; }
			set
			{
				this._FirstProperty = value;
				RaisePropertyChanged(() => this.FirstProperty);
				UpdateCombinedProperty();
			}
		}
		private string _SecondProperty = "";
		public string SecondProperty
		{
			get { return this._SecondProperty; }
			set
			{
				this._SecondProperty = value;
				RaisePropertyChanged(() => this.SecondProperty);
				UpdateCombinedProperty();
			}
		}
		private string _CombinedProperty = "";
		public string CombinedProperty
		{
			get { return this._CombinedProperty; }
			set
			{
				this._CombinedProperty = value;
				RaisePropertyChanged(() => this.CombinedProperty);
				UpdateSourceProperties();
			}
		}
		private void UpdateCombinedProperty()
		{
			this.CombinedProperty = this.FirstProperty + " " + this.SecondProperty;
		}
		private void UpdateSourceProperties()
		{
			var fields = this.CombinedProperty.Split(' ');
			if (fields.Length != 2)
				return; // should handle validation properly
			this.FirstProperty = fields[0];
			this.SecondProperty = fields[1];
		}
		
	}
