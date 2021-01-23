    Page1.xaml   
     <Page
            x:Class="test1.BlankPage1"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="using:test1"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            mc:Ignorable="d">
        
            <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
                <Button Content="goto page2" Click="Button_Click"/>
            </Grid>
        </Page>
    
    Page1.xaml.cs
    public sealed partial class BlankPage1: Page
        {
            public BlankPage1()
            {
                this.InitializeComponent();
                this.Loaded += BlankPage1_Loaded;
            }
    
            private void BlankPage1_Loaded(object sender, RoutedEventArgs e)
            {
                if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                {
                    Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
                }
                else
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                    SystemNavigationManager.GetForCurrentView().BackRequested += (s, e1) =>
                    {
                        if (this.Frame.CanGoBack)
                            this.Frame.GoBack();
                    };
                }
    
            }
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            }
            private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    e.Handled = true;
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(BlankPage2));
            }
        }
    page2.xaml
    
    <Page
        x:Class="test1.BlankPage2"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:test1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Button Content="goto page3" Click="Button_Click"/>
        </Grid>
    </Page>
    page2.xaml.cs
    
      public sealed partial class BlankPage2 : Page
        {
            public BlankPage2()
            {
                this.InitializeComponent();
                this.Loaded += BlankPage2_Loaded;
            }
            private void BlankPage2_Loaded(object sender, RoutedEventArgs e)
            {
                if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                {
                    Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
                }
                else
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                    SystemNavigationManager.GetForCurrentView().BackRequested += (s, e1) =>
                    {
                        if (this.Frame.CanGoBack)
                            this.Frame.GoBack();
                    };
                }
            }
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            }
            private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    e.Handled = true;
                }
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(BlankPage3));
            }
    }
    page3.xaml
    <Page
        x:Class="test1.BlankPage3"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:test1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Button Content="goback to page2" Click="Button_Click"/>
        </Grid>
    </Page>
    
    page3.xaml.cs
     public sealed partial class BlankPage3 : Page
        {
            public BlankPage3()
            {
                this.InitializeComponent();
                this.Loaded += BlankPage3_Loaded;
            }
    
            private void BlankPage3_Loaded(object sender, RoutedEventArgs e)
            {
                if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                {
                    Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
                }
                else
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                    SystemNavigationManager.GetForCurrentView().BackRequested += (s, e1) =>
                    {
                        if (this.Frame.CanGoBack)
                            this.Frame.GoBack();
                    };
                }
    
            }
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                base.OnNavigatedFrom(e);
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            }
            private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    e.Handled = true;
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (Frame.CanGoBack)
                {
                   Frame.GoBack();
                }
            }
        }
