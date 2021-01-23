    <Page
        x:Class="Cache.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:Cache"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup>
    
                    <VisualState>
                        <VisualState.StateTriggers>
                            <AdaptiveTrigger MinWindowWidth="450" />
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                            <Setter Target="RootSpiltView.DisplayMode" Value="CompactInline" />
                            <Setter Target="RootSpiltView.IsPaneOpen" Value="true" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState>
                        <VisualState.StateTriggers>
                            <AdaptiveTrigger MinWindowWidth="0" />
                        </VisualState.StateTriggers>
                        <VisualState.Setters>
                            <Setter Target="RootSpiltView.DisplayMode" Value="CompactInline" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <SplitView x:Name="RootSpiltView" OpenPaneLength="200" CompactPaneLength="50" DisplayMode="CompactOverlay" >
    
                <SplitView.Pane>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <StackPanel Grid.Row="0" Height="auto">
                            <Button BorderThickness="0" Background="Transparent" Click="Button_Click_Pane">
                                <Button.Content>
                                    <TextBlock Text="&#xE700;" FontFamily="Segoe MDL2 Assets" FontSize="24" />
                                </Button.Content>
                            </Button>
                        </StackPanel>
                        <TextBlock Text="MainPage_Splitview_Pane" Grid.Row="1" VerticalAlignment="Center" HorizontalAlignment="Center" />
                        <Button Grid.Row="1" HorizontalAlignment="Center" Content="MainPageToPage1" Margin="0,80,0,0" Click="MainPageToPage1"/>
                    </Grid>
                </SplitView.Pane>
                <SplitView.Content>
                    <Frame x:Name="frame" Background="Transparent" Navigating="OnFrameNavigating" Navigated="OnFrameNavigated">
                        <Button HorizontalAlignment="Center" VerticalAlignment="Center" Content="FrameToPage2" Click="FrameToPage2"/>
                    </Frame>
                </SplitView.Content>
            </SplitView>
        </Grid>
    </Page>  
   
    MainPage:
    namespace Cache
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            private void Button_Click_Pane(object sender, RoutedEventArgs e)
            {
                this.RootSpiltView.IsPaneOpen = !this.RootSpiltView.IsPaneOpen; 
            }
    
            private void OnFrameNavigating(object sender, NavigatingCancelEventArgs e)
            {
                string msg = "Frame's Navigating event happening, SourcePageType = {0}";
                System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
            }
    
            private void OnFrameNavigated(object sender, NavigationEventArgs e)
            {
                string msg = "Frame's Navigated event happening, SourcePageType = {0}";
                System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
            }
    
            private void FrameToPage2(object sender, RoutedEventArgs e)
            {
                frame.Navigate(typeof(Page2));
            }
    
            private void MainPageToPage1(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(Page1));
            }
        }
    }
