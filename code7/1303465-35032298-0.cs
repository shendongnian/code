    <Window x:Class="DataTemplateInResDectReuseHelpAttempt.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:dataTemplateInResDectReuseHelpAttempt="clr-namespace:DataTemplateInResDectReuseHelpAttempt"
        Title="MainWindow" Height="350" Width="525">
    <Window.DataContext>
        <dataTemplateInResDectReuseHelpAttempt:MainDataContext/>
    </Window.DataContext>
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ContactsDataTemplateResourceDictionary.xaml"></ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <ListBox ItemsSource="{Binding BaseModels}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="ContentTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <ContentControl Content="{Binding }" ContentTemplate="{StaticResource ContactItemTemplate}"></ContentControl>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
    </Grid></Window>
