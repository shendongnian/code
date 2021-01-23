// ... using, namespace etc
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
// ...
**MainPage.xaml**
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MyApp"
             x:Class="MyApp.MainPage"
             NavigationPage.HasNavigationBar="False"
             Title="My App">
    <ContentPage.ToolbarItems>
        <ToolbarItem Name="Back" Clicked="OnBack"></ToolbarItem>
    </ContentPage.ToolbarItems>
    
    <WebView x:Name="browser" Navigating="OnNavigating"></WebView>
</ContentPage>
**MainPage.xaml.cs**
using System;
using Xamarin.Forms;
namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        string Url;
        public MainPage()
        {
            InitializeComponent();
            browser.Source = Url = GetUrl();
        }
        void OnBack(object sender, EventArgs args)
        {
            browser.GoBack();
        }
        protected override bool OnBackButtonPressed()
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
                return true;
            }
            else return base.OnBackButtonPressed();
        }
        void OnNavigating(object sender, WebNavigatingEventArgs args)
        {
            // Checking if we are at the home page url
            // browser.CanGoBack does not seem to be working (not updating in time)
            NavigationPage.SetHasNavigationBar(this, args.Url != Url);
        }
        string GetUrl()
        {
            // Possibly some mechanism to accomoddate for several locales
            return "...";
        }
    }
}
