    <Window.Resources>
        <CollectionViewSource x:Key="GroupedItems" Source="{Binding Countries}"/>
    </Window.Resources>
    ...
    <ItemsControl ItemsSource="{Binding Source={StaticResource GroupedItems}}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Expander Header="{Binding Name}">
                            <ItemsControl ItemsSource="{Binding Leagues}" Margin="25 0 0 0">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Expander Header="{Binding Name}">
                                            <ItemsControl ItemsSource="{Binding Matches}" Margin="25 0 0 0">
                                                <ItemsControl.ItemTemplate>
                                                    <DataTemplate>
                                                        <TextBlock Text="{Binding Name}"/>
                                                    </DataTemplate>
                                                </ItemsControl.ItemTemplate>
                                            </ItemsControl>
                                        </Expander>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </Expander>         
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
     </ItemsControl>
