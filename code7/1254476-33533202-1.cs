		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new StarSystem
			{
				Diameter = 300,
				Sectors = new ObservableCollection<Sector>{
					new Sector{Name="Sector 1", X=50, Y=50, Size=110},
					new Sector{Name="Sector 2", X=160, Y=190, Size=90},
					new Sector{Name="Sector 3", X=225, Y=70, Size=70},
				}
			};
		}
