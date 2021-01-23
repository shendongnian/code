		private Dictionary<string, List<TransformerStation>> _AllStations;
		public Dictionary<string, List<TransformerStation>> AllStations
		{
			get { return this._AllStations; }
			private set { this._AllStations = value; RaisePropertyChanged(); }
		}
		
		private string _SelectedRadial;
		public string SelectedRadial
		{
			get { return this._SelectedRadial; }
			set
			{
				this._SelectedRadial = value;
				RaisePropertyChanged();
				this.CurrentStations = this.AllStations[value];
			}
		}
		private List<TransformerStation> _CurrentStations;
		public List<TransformerStation> CurrentStations
		{
			get { return this._CurrentStations; }
			private set { this._CurrentStations = value; RaisePropertyChanged(() => this.CurrentStations); }
		}
		public ICommand RadialCommand {get { return new RelayCommand<string>(OnRadialCommand); }}
		private void OnRadialCommand(string radial)
		{
			this.SelectedRadial = radial;
		}
		
        public MainViewModel()
        {
			this.AllStations = ReadCSV(@"data.csv");
        }
