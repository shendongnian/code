	public class StarSystem : ViewModelBase
	{
		private ObservableCollection<Sector> _Sectors;
		public ObservableCollection<Sector> Sectors
		{
			get { return this._Sectors; }
			set { this._Sectors = value; RaisePropertyChanged(); }
		}
		private double _Diameter;
		public double Diameter
		{
			get { return this._Diameter; }
			set { this._Diameter = value; RaisePropertyChanged(); }
		}
		
	}
	public class Sector : ViewModelBase
	{
		private string _Name;
		public string Name
		{
			get { return this._Name; }
			set { this._Name = value; RaisePropertyChanged(); }
		}
		
		private double _X;
		public double X
		{
			get { return this._X;}
			set { this._X = value; RaisePropertyChanged(); }
		}
		private double _Y;
		public double Y
		{
			get { return this._Y;}
			set { this._Y = value; RaisePropertyChanged(); }
		}
		private double _Size;
		public double Size
		{
			get { return this._Size; }
			set { this._Size = value; RaisePropertyChanged(); }
		}
