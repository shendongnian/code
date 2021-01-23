    <Grid.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/Styles.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Grid.Resources>
    ...
    <ItemsControl
        ItemsSource="{Binding People}"
        Grid.Row="3"
        ItemTemplate="{StaticResource ContactItemTemplate}" />
