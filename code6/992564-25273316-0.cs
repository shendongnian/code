    MainPage.xaml
    <Page>
        <Page.BottomAppBar>
            <CommandBar>
                <CommandBar.PrimaryCommands>
                    <AppBarButton Icon="Add" Label="Add" Click="NavigateToAddApple"/>
                </CommandBar.PrimaryCommands>
            </CommandBar>
        </Page.BottomAppBar>
        <Hub>
            ...
        </Hub>
    </Page>
---
    Main.xaml.cs
    public void NavigateToAddApple(object sender, RoutedEventArgs e) 
    {
        Frame.Navigate(typeof(AddApplePage));
    }
