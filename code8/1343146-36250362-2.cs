	using System.Collections.Generic;
	using System.Windows;
	
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			FavoriteProductCollectionViewModelIns = new List<FavoriteProductViewModel>
			{
				new FavoriteProductViewModel {Name = "Menu 1"},
				new FavoriteProductViewModel {Name = "Menu 2"}
			};
			DataContext = this;
			popup.PlacementTarget = FavoriteProductButton;
		}
	
		public class FavoriteProductViewModel
		{
			public string Name { get; set; }
		}
	
		public List<FavoriteProductViewModel> FavoriteProductCollectionViewModelIns { get; set; }
	
		private void btn_Click(object sender, RoutedEventArgs e)
		{
			popup.Visibility = Visibility.Visible;
			popup.IsOpen = true;
		}
	}
