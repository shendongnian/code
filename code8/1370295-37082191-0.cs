    <ItemsControl ItemsSource="{Binding Data}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
         <ItemsControl.Template>
            <ControlTemplate>
                <ScrollViewer HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Disabled">
                    <ItemsPresenter SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}"/>
                </ScrollViewer>
            </ControlTemplate>
        </ItemsControl.Template>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border>
                    <ItemsControl ItemsSource="{Binding Value}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Grid.RowDefinitions>
                                        <RowDefinition SharedSizeGroup="SomeCellRowSize"/>
                                    </Grid.RowDefinitions>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition SharedSizeGroup="SomeCellRowSize"/>
                                    </Grid.ColumnDefinitions>
                                    <TextBox
                                        Text="{Binding Value.TotalTime}"
                                        HorizontalContentAlignment="Right" BorderThickness="0" Margin="1,1,0,0"/>
                                </Grid>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
