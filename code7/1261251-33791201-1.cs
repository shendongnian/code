    <ToolBar Name="SomeToolBar" ItemsSource="{Binding Items}">
        <ToolBar.ItemTemplate>
            <DataTemplate DataType="local:ItemViewModel">
                <Button Command="{Binding Command}" Content="{Binding Name}" Click="ButtonBase_OnClick"/>
            </DataTemplate>
        </ToolBar.ItemTemplate>
    </ToolBar>
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		SomeToolBar.IsOverflowOpen = false;
	}
