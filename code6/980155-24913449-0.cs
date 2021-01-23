    <ListView ItemsSource="{Binding Orders}">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="State">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <ListView ItemsSource="{Binding States}">
                                <ListView.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <StackPanel Orientation="Horizontal"></StackPanel>
                                    </ItemsPanelTemplate>
                                </ListView.ItemsPanel>
                                <ListView.Resources>
                                    <Style TargetType="GridViewColumnHeader">
                                        <Setter Property="Visibility" Value="Collapsed" />
                                    </Style>
                                </ListView.Resources>
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn>
                                            <GridViewColumn.CellTemplate>
                                                <DataTemplate>
                                                    <CheckBox IsChecked="{Binding Value}" Content="{Binding Text}" />
                                                </DataTemplate>
                                            </GridViewColumn.CellTemplate>
                                        </GridViewColumn>
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header="OrderNo" DisplayMemberBinding="{Binding OrderNo}" />
            </GridView>
        </ListView.View>
    </ListView>
