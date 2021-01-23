		using System.Windows.Navigation;
	within:
	
	public partial class MyPage : Page
	
	
	private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Doelen nextPage = new Doelen();
        NavigationService.Navigate(nextPage);
    }
