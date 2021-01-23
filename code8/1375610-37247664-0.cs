    <Window x:Class="WpfApplication5.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication5"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <DataTemplate x:Key="NormalUserDataTemplate">
                <StackPanel>
                    <TextBlock Text="{Binding Name}" />
                </StackPanel>
            </DataTemplate>
            <DataTemplate x:Key="PremiumUserDataTemplate">
                <StackPanel Background="LightBlue">
                    <TextBlock Text="{Binding Name}" />
                </StackPanel>
            </DataTemplate>
            <local:PremiumUserDataTemplateSelector x:Key="myPremiumUserDataTemplateSelector" />
        </Window.Resources>
        <Grid>
            <ListView x:Name="myListView" ItemTemplateSelector="{StaticResource myPremiumUserDataTemplateSelector}">
            </ListView>
        </Grid>
    </Window>
