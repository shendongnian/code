     <TabControl ItemsSource="{Binding Tabs}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding Header}" />
            </Style>
        </TabControl.ItemContainerStyle>
        <TabControl.ItemTemplate>
            <DataTemplate>
                <ContentPresenter Content="{Binding Converter={StaticResource ViewModelToViewConverter}}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
