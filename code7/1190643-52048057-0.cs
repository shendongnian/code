        void proxy_ControlAvailable(object sender, ControlAvailableEventArgs e)
		{
			var ctrl = (DataGrid)e.Control;
			ctrl.LoadingRow += new EventHandler<DataGridRowEventArgs>(Ctrl_LoadingRow);
		}
		private void Ctrl_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			//Getting a particular cell is tricky, 
			// you have cross reference the row instance in the particular
			// column you want to find, and then get that thing's parent, 
			// which happens to be the DataGridCell you can control the rendering of.
			DataGrid grid = (DataGrid)sender;
			DataGridRow row = new DataGridRow();
			row = e.Row;
			var cell = (grid.Columns.First(item => item.SortMemberPath == nameof(MySpecialConfiguration.MyColor))
				.GetCellContent(row) as Microsoft.LightSwitch.Presentation.Framework.ContentItemPresenter)
				.Parent as DataGridCell;
			
			Binding bgbinding = new Binding(nameof(MySpecialConfiguration.MyColor))
			{
				Mode = BindingMode.TwoWay,
				Converter = new RowColorConverter(),
				ValidatesOnExceptions = true
			};
			cell.SetBinding(DataGridCell.BackgroundProperty, bgbinding);
		}
		partial void MySpecialConfiguration_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
		{
			Microsoft.LightSwitch.Threading.Dispatchers.Main.BeginInvoke(() =>
			{
				var proxy = this.FindControl(nameof(MySpecialConfigurationGrid));
				proxy.ControlAvailable += new EventHandler<ControlAvailableEventArgs>(proxy_ControlAvailable);
			});
		}
		public class RowColorConverter : IValueConverter
		{
			public RowColorConverter() { }
			#region IValueConverter Members
			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				if (value != null)
				{
					var match = Regex.Match(value as string, "#(?<R>[a-fA-F0-9]{2})(?<G>[a-fA-F0-9]{2})(?<B>[a-fA-F0-9]{2})");
					if (match.Success)
					{
						return new System.Windows.Media.SolidColorBrush(Color.FromArgb(255,
							sToB(match.Groups["R"].Value),
							sToB(match.Groups["G"].Value),
							sToB(match.Groups["B"].Value)));
					}
				}
				
				return new System.Windows.Media.SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
			}
			private byte sToB(string s)
			{
				return byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
			}
			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				throw new NotImplementedException();
			}
			#endregion
		}
