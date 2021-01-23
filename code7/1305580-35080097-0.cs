    <ItemsControl Name="lviewLookupResult"  Background="#363636">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal" Margin="5 5 5 0">
                        <Label Margin="5 0" Padding="0"  Content="{Binding word}" />
                        <ListView ItemsSource="{Binding meanings}">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <StackPanel Orientation="Horizontal">
                                        <Label Content="{Binding}"/>
                                    </StackPanel>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
                    </StackPanel>
                   
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
