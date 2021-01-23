    <Window.Resources>
        <local:CollectionConverter x:Key="collectionConverter" />
        <CollectionViewSource x:Key="ExistingTabs" Source="{Binding Path=(local:ReportDataSet.testData), Converter={StaticResource collectionConverter}, UpdateSourceTrigger=PropertyChanged}"/>
    </Window.Resources>
    <TabControl>
        <TabControl.ItemsSource>
            <CompositeCollection>
                <TabItem Header="test">
                    <StackPanel>
                        <Button Content="Add new item" Click="AddNewTabItem"></Button>
                        <Button Content="Remove last item" Click="RemoveLastItem"></Button>
                    </StackPanel>
                </TabItem>
                <CollectionContainer Collection="{Binding Source={StaticResource ExistingTabs}}" >
                </CollectionContainer>
            </CompositeCollection>
        </TabControl.ItemsSource>
    </TabControl>
