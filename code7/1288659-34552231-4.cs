	public class TransformerStation : ViewModelBase
	{
		private string _Name;
		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; RaisePropertyChanged(); }
		}
		private string _Radial;
		public string Radial
		{
			get { return this._Radial; }
			set { this._Radial = value; RaisePropertyChanged(); }
		}
		private string _Area;
		public string Area
		{
			get { return this._Area; }
			set { this._Area = value; RaisePropertyChanged(); }
		}
		public TransformerStation(string name, string radial, string area)
		{
			this.Name = name;
			this.Radial = radial;
			this.Area = area;
		}
	}
