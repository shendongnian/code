    public class MainPage:Page
    {
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.PrimaryButtons = Views.Shell.HamburgerMenu.PrimaryButtons;
            ViewModel.SecondaryButtons = Views.Shell.HamburgerMenu.SecondaryButtons;
        }
    }
    public class MainPageViewModel
    {
        Windows.Foundation.Collections.IObservableVector<ICommandBarElement> PrimaryButtons { get; set; }
        Windows.Foundation.Collections.IObservableVector<ICommandBarElement> SecondaryButtons { get; set; }
    }
